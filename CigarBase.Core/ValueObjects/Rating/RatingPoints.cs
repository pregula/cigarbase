using CigarBase.Core.Exceptions.Rating;

namespace CigarBase.Core.ValueObjects.Rating;

public sealed record RatingPoints
{
    public int Value { get; }

    public RatingPoints(int value)
    {
        if (value is < 0 or > 100)
        {
            throw new InvalidRatingPointsException(value);
        }
        Value = value;
    }

    public static implicit operator int(RatingPoints ratingPoints) => ratingPoints.Value;
    public static implicit operator RatingPoints(int value) => new(value);
}