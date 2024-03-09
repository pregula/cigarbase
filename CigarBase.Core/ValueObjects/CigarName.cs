using CigarBase.Core.Exceptions;

namespace CigarBase.Core.ValueObjects;

public sealed record CigarName
{
    public string Value { get; }

    public CigarName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidCigarNameException();
        }
        Value = value;
    }

    public static implicit operator string(CigarName cigarName) => cigarName.Value;
    public static implicit operator CigarName(string value) => new(value);
    public override string ToString() => Value;
}