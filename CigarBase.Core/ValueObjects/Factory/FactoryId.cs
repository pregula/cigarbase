using CigarBase.Core.Exceptions;

namespace CigarBase.Core.ValueObjects.Factory;

public sealed record FactoryId
{
    public Guid Value { get; }

    public FactoryId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }
        Value = value;
    }

    public static FactoryId Create() => new(Guid.NewGuid());
    public static implicit operator Guid(FactoryId factoryId) => factoryId.Value;
    public static implicit operator FactoryId(Guid value) => new(value);
    public override string ToString() => Value.ToString("N");
}