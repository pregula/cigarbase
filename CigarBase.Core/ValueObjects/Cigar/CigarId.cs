using CigarBase.Core.Exceptions;

namespace CigarBase.Core.ValueObjects.Cigar;

public sealed record CigarId
{
    public Guid Value { get; }

    public CigarId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }
        Value = value;
    }

    public static CigarId Create() => new(Guid.NewGuid());
    public static implicit operator Guid(CigarId date) => date.Value;
    public static implicit operator CigarId(Guid value) => new(value);
    public override string ToString() => Value.ToString("N");
}