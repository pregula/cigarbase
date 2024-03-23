using CigarBase.Core.Exceptions.Factory;

namespace CigarBase.Core.ValueObjects.Factory;

public sealed record FactoryName
{
    public string Value { get; }

    public FactoryName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidFactoryNameException();
        }
        Value = value;
    }

    public static implicit operator string(FactoryName factoryName) => factoryName.Value;
    public static implicit operator FactoryName(string value) => new(value);
    public override string ToString() => Value;
}