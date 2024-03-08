using CigarBase.Core.Exceptions;

namespace CigarBase.Core.ValueObjects;

public record RatingId
{
    public Guid Value { get; }
    public RatingId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }

        Value = value;
    }

    public static RatingId Create() => new(Guid.NewGuid());
    public static implicit operator Guid(RatingId data) => data.Value;
    public static implicit operator RatingId(Guid value) => new(value);
}