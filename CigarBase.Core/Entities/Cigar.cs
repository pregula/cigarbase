using CigarBase.Core.Exceptions.Cigar;
using CigarBase.Core.ValueObjects;
using CigarBase.Core.ValueObjects.Cigar;
using CigarBase.Core.ValueObjects.Rating;

namespace CigarBase.Core.Entities;

public sealed class Cigar
{
    public CigarId Id { get; private set; }
    public CigarFullName FullName { get; private set; }
    public CigarDescription Description { get; private set; }
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
}