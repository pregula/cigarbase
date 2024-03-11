using CigarBase.Core.ValueObjects;
using CigarBase.Core.ValueObjects.Cigar;
using CigarBase.Core.ValueObjects.Rating;

namespace CigarBase.Core.Entities;

public sealed class Cigar
{
    public CigarId Id { get; private set; }
    public CigarName Name { get; private set; }
    public CigarDescription Description { get; private set; }
    public Date CreatedAt { get; private set; }
    private readonly HashSet<Rating> _ratings = new();
    public IEnumerable<Rating> Ratings => _ratings;

    private Cigar(CigarId id, CigarName name, CigarDescription description, Date createdAt)
    {
        Id = id;
        Name = name;
        Description = description;
        CreatedAt = createdAt;
    }

    public static Cigar Create(CigarId id, CigarName name, CigarDescription description, Date createdAt)
        => new(id, name, description, createdAt);
    public void AddRating(Rating rating) => _ratings.Add(rating);
    public void RemoveRating(RatingId ratingId)
        => _ratings.RemoveWhere(r => r.Id == ratingId);
}