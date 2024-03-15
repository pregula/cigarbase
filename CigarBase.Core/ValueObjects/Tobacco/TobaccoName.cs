using CigarBase.Core.Exceptions.Tobacco;

namespace CigarBase.Core.ValueObjects.Tobacco;

public sealed record TobaccoName
{
    public string Value { get; }
    
    public TobaccoName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidTobaccoNameException(value);
        }
        
        Value = value;
    }

    public static implicit operator string(TobaccoName tobaccoName) => tobaccoName.Value;
    public static implicit operator TobaccoName(string value) => new(value);
    public override string ToString() => Value;
}