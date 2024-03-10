using CigarBase.Core.Exceptions.User;

namespace CigarBase.Core.ValueObjects.User;

public sealed record Password
{
    public string Value { get; }

    public Password(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 8)
        {
            throw new InvalidPasswordException();
        }
        
        Value = value;
    }

    public static implicit operator string(Password password) => password.Value;
    public static implicit operator Password(string value) => new(value);
    public override string ToString() => Value;
}