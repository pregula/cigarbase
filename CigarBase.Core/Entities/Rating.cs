using CigarBase.Core.ValueObjects;

namespace CigarBase.Core.Entities;

public sealed class Rating
{
    public RatingId Id { get; private set; }
    public CigarId CigarId { get; private set; }
}