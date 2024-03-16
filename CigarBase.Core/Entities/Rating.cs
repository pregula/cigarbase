using CigarBase.Core.ValueObjects;
using CigarBase.Core.ValueObjects.Cigar;
using CigarBase.Core.ValueObjects.Rating;
using CigarBase.Core.ValueObjects.User;

namespace CigarBase.Core.Entities;

public sealed class Rating
{
    public RatingId Id { get; private set; }
    public RatingDescription Description { get; private set; }
    public RatingPoints Points { get; private set; }
    public Date CreatedAt { get; private set; }
    public UserId UserId { get; private set; }
    public CigarId CigarId { get; private set; }

    public Rating(RatingId id, RatingDescription description, RatingPoints points, UserId userId, CigarId cigarId, Date createdAt)
    {
        Id = id;
        ChangeDescription(description);
        ChangePoints(points);
        UserId = userId;
        CigarId = cigarId;
        CreatedAt = createdAt;
    }

    public void ChangeDescriptionAndPoints(RatingDescription description, RatingPoints points)
    {
        ChangeDescription(description);
        ChangePoints(points);
    }
    private void ChangeDescription(RatingDescription description)
        => Description = description;
    private void ChangePoints(RatingPoints points)
        => Points = points;
}