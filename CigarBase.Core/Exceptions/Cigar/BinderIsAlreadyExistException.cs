namespace CigarBase.Core.Exceptions.Cigar;

public sealed class BinderIsAlreadyExistException : CustomException
{
    public BinderIsAlreadyExistException() : base("Binder is already exist.")
    {
    }
}