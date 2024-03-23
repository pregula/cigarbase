using CigarBase.Core.Exceptions.Cigar;
using CigarBase.Core.ValueObjects;
using CigarBase.Core.ValueObjects.Cigar;
using CigarBase.Core.ValueObjects.CigarTobaccoComponent;
using CigarBase.Core.ValueObjects.Rating;
using CigarBase.Core.ValueObjects.Region;

namespace CigarBase.Core.Entities;

public sealed class Cigar
{
    public CigarId Id { get; private set; }
    public CigarFullName FullName { get; private set; }
    public CigarDescription Description { get; private set; }
    private readonly HashSet<CigarWrapper> _wrappers = new();
    public IEnumerable<CigarWrapper> Wrappers => _wrappers;
    private readonly HashSet<CigarFiller> _fillers = new();
    public IEnumerable<CigarFiller> Fillers => _fillers;
    public CigarBinder Binder { get; private set; }
    public RegionId CountryId { get; private set; }
    public Region Country { get; private set; }
    public Date CreatedAt { get; private set; }
    private readonly HashSet<Rating> _ratings = new();
    public IEnumerable<Rating> Ratings => _ratings;

    private Cigar(CigarId id, CigarFullName fullName, CigarDescription description, RegionId countryId, Date createdAt)
    {
        Id = id;
        FullName = fullName;
        Description = description;
        CountryId = countryId;
        CreatedAt = createdAt;
    }

    public static Cigar Create(CigarId id, CigarFullName fullName, CigarDescription description, RegionId countryId, Date createdAt)
        => new(id, fullName, description, countryId, createdAt);
    public void AddRating(Rating rating)
    {
        var isRatingExist = _ratings.Any(r => r.UserId == rating.UserId);
        if (isRatingExist)
        {
            throw new MultipleRatingSingleCigarBySingleUserException(Id, rating.UserId);
        }
        _ratings.Add(rating);
    }

    public void RemoveRating(RatingId ratingId)
        => _ratings.RemoveWhere(r => r.Id == ratingId);

    public void AddWrapper(CigarWrapper wrapper)
    {
        if (_wrappers.Any(w => w.RegionId == wrapper.RegionId))
        {
            throw new WrapperWithTheSameRegionIdAlreadyExistException(wrapper.RegionId);
        }
        
        _wrappers.Add(wrapper);
    }
    
    public void RemoveWrapper(CigarTobaccoComponentId wrapperId)
        => _wrappers.RemoveWhere(r => r.Id == wrapperId);
    
    public void AddFiller(CigarFiller filler)
    {
        if (_fillers.Any(w => w.RegionId == filler.RegionId))
        {
            throw new FillerWithTheSameRegionIdAlreadyExistException(filler.RegionId);
        }
        
        _fillers.Add(filler);
    }
    
    public void RemoveFiller(CigarTobaccoComponentId fillerId)
        => _fillers.RemoveWhere(r => r.Id == fillerId);
    
    public void AddBinder(CigarBinder binder)
    {
        if (Binder is not null)
        {
            throw new BinderAlreadyExistException();
        }

        Binder = binder;
    }

    public void RemoveBinder()
        => Binder = null;
}