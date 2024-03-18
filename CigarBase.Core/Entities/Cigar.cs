using CigarBase.Core.Exceptions.Cigar;
using CigarBase.Core.ValueObjects;
using CigarBase.Core.ValueObjects.Cigar;
using CigarBase.Core.ValueObjects.CigarTobaccoComponent;
using CigarBase.Core.ValueObjects.Rating;

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
    public Date CreatedAt { get; private set; }
    private readonly HashSet<Rating> _ratings = new();
    public IEnumerable<Rating> Ratings => _ratings;

    private Cigar(CigarId id, CigarFullName fullName, CigarDescription description, Date createdAt)
    {
        Id = id;
        FullName = fullName;
        Description = description;
        CreatedAt = createdAt;
    }

    public static Cigar Create(CigarId id, CigarFullName fullName, CigarDescription description, Date createdAt)
        => new(id, fullName, description, createdAt);
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
        if (_wrappers.Any(w => wrapper.TobaccoId is not null && w.TobaccoId == wrapper.TobaccoId))
        {
            throw new WrapperIsAlreadyExistException(wrapper.TobaccoId);
        }

        if (_wrappers.Count(w => w.RegionId == wrapper.RegionId && w.TobaccoId == null) > 1)
        {
            throw new WrapperRegionWithoutTobaccoAlreadyExistException(wrapper.RegionId);
        }
        _wrappers.Add(wrapper);
    }
    
    public void RemoveWrapper(CigarTobaccoComponentId wrapperId)
        => _wrappers.RemoveWhere(r => r.Id == wrapperId);
    
    public void AddFiller(CigarFiller filler)
    {
        if (_fillers.Any(w => filler.TobaccoId is not null && w.TobaccoId == filler.TobaccoId))
        {
            throw new FillerIsAlreadyExistException(filler.TobaccoId);
        }

        if (_fillers.Count(w => w.RegionId == filler.RegionId && w.TobaccoId == null) > 1)
        {
            throw new FillerRegionWithoutTobaccoAlreadyExistException(filler.RegionId);
        }
        _fillers.Add(filler);
    }
    
    public void RemoveFiller(CigarTobaccoComponentId fillerId)
        => _fillers.RemoveWhere(r => r.Id == fillerId);
    
    public void AddBinder(CigarBinder binder)
    {
        if (Binder is not null)
        {
            throw new BinderIsAlreadyExistException();
        }

        Binder = binder;
    }

    public void RemoveBinder()
        => Binder = null;
}