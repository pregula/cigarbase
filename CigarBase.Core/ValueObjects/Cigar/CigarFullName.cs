using CigarBase.Core.Exceptions.Cigar;

namespace CigarBase.Core.ValueObjects.Cigar;

public sealed record CigarFullName
{
    public string Value { get; }

    public CigarFullName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidCigarFullNameException();
        }
        Value = value;
    }

    public static implicit operator string(CigarFullName cigarFullName) => cigarFullName.Value;
    public static implicit operator CigarFullName(string value) => new(value);
    public override string ToString() => Value;
}