using CigarBase.Core.Exceptions.Rating;

namespace CigarBase.Core.ValueObjects.Rating;

public sealed record RatingDescription
{
    public string Value { get; }
    
    public RatingDescription(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 2000)
        {
            throw new InvalidRatingDescriptionException(value);
        }
        Value = value;
    }

    public static implicit operator string(RatingDescription ratingDescription) => ratingDescription.Value;
    public static implicit operator RatingDescription(string value) => new(value);
    public override string ToString() => Value;
}