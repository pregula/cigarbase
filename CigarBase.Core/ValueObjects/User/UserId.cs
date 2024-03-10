using CigarBase.Core.Exceptions;

namespace CigarBase.Core.ValueObjects.User;

public sealed record UserId
{
    public Guid Value { get; }
    
    public UserId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }
        
        Value = value;
    }

    public static UserId Create() => new (Guid.NewGuid());
    public static implicit operator Guid(UserId userId) => userId.Value;
    public static implicit operator UserId(Guid value) => new UserId(value);
    public override string ToString() => Value.ToString("N");
}