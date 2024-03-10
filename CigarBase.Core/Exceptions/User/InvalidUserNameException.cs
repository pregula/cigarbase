namespace CigarBase.Core.Exceptions.User;

public sealed class InvalidUserNameException : CustomException
{
    public string UserName { get; }
    public InvalidUserNameException(string userName) : base($"User name {userName} is invalid.")
    {
        UserName = userName;
    }
}