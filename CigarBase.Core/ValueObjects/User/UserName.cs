using CigarBase.Core.Exceptions.User;

namespace CigarBase.Core.ValueObjects.User;

public sealed record UserName
{
    public string Value { get; }

    public UserName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidUserNameException(value);
        }
        
        Value = value;
    }

    public static implicit operator string(UserName userName) => userName.Value;
    public static implicit operator UserName(string value) => new(value);
}