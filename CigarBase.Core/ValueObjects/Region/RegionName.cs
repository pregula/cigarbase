using CigarBase.Core.Exceptions.Region;

namespace CigarBase.Core.ValueObjects.Region;

public sealed record RegionName
{
    public string Value { get; }

    public RegionName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidRegionNameException();
        }
        Value = value;
    }

    public static implicit operator string(RegionName cigarFullName) => cigarFullName.Value;
    public static implicit operator RegionName(string value) => new(value);
    public override string ToString() => Value;
}