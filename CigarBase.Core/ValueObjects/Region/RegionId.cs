using CigarBase.Core.Exceptions;

namespace CigarBase.Core.ValueObjects.Region;

public sealed record RegionId
{
    public Guid Value { get; }

    public RegionId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }
        Value = value;
    }

    public static RegionId Create() => new(Guid.NewGuid());
    public static implicit operator Guid(RegionId date) => date.Value;
    public static implicit operator RegionId(Guid value) => new(value);
    public override string ToString() => Value.ToString("N");
}