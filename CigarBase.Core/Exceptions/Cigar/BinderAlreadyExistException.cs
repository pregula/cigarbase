namespace CigarBase.Core.Exceptions.Cigar;

public sealed class BinderAlreadyExistException : CustomException
{
    public BinderAlreadyExistException() : base("Binder already exist.")
    {
    }
}