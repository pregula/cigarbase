namespace CigarBase.Core.Exceptions.Cigar;

public sealed class InvalidCigarNameException : CustomException
{
    public InvalidCigarNameException() : base("Cigar name is invalid.")
    {
    }
}