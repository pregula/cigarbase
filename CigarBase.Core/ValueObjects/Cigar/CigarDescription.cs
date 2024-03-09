using CigarBase.Core.Exceptions.Cigar;

namespace CigarBase.Core.ValueObjects.Cigar;

public sealed record CigarDescription
{
    public string Value { get; }

    public CigarDescription(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 2000)
        {
            throw new InvalidCigarDescriptionException(value);
        }
        Value = value;
    }

    public static implicit operator string(CigarDescription cigarDescription) => cigarDescription.Value;
    public static implicit operator CigarDescription(string value) => new(value);
    public override string ToString() => Value;
}