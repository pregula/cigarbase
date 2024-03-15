using CigarBase.Core.Exceptions;

namespace CigarBase.Core.ValueObjects.Tobacco;

public sealed record TobaccoId
{
    public Guid Value { get; }
    
    public TobaccoId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }
        Value = value;
    }

    public static TobaccoId Create() => new(Guid.NewGuid());
    public static implicit operator Guid(TobaccoId tobaccoId) => tobaccoId.Value;
    public static implicit operator TobaccoId(Guid value) => new(value);
    
}