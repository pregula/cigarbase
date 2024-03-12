namespace CigarBase.Core.Exceptions.Cigar;

public sealed class InvalidCigarFullNameException : CustomException
{
    public InvalidCigarFullNameException() : base("Cigar name is invalid.")
    {
    }
}