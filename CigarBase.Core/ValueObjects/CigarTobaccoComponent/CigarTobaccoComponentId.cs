using CigarBase.Core.Exceptions;

namespace CigarBase.Core.ValueObjects.CigarTobaccoComponent;

public sealed record CigarTobaccoComponentId
{
    public Guid Value { get; }

    public CigarTobaccoComponentId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }
        Value = value;
    }

    public static CigarTobaccoComponentId Create() => new(Guid.NewGuid());
    public static implicit operator Guid(CigarTobaccoComponentId date) => date.Value;
    public static implicit operator CigarTobaccoComponentId(Guid value) => new(value);
    public override string ToString() => Value.ToString("N");
}