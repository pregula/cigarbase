namespace CigarBase.Core.Exceptions;

public sealed class InvalidCigarNameException : CustomException
{
    public InvalidCigarNameException() : base("Cigar name is invalid.")
    {
    }
}