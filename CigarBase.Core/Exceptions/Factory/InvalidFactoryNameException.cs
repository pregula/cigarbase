namespace CigarBase.Core.Exceptions.Factory;

public sealed class InvalidFactoryNameException : CustomException
{
    public InvalidFactoryNameException() : base($"Factory name is invalid. ")
    {
    }
}