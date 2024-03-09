using CigarBase.Core.ValueObjects.Cigar;
using CigarBase.Core.ValueObjects.Rating;

namespace CigarBase.Core.Entities;

public sealed class Rating
{
    public RatingId Id { get; private set; }
    public RatingDescription Description { get; private set; }
    public RatingPoints Points { get; private set; }
    public CigarId CigarId { get; private set; }
}