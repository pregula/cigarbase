namespace CigarBase.Core.Exceptions.Cigar;

public sealed class InvalidCigarDescriptionException : CustomException
{
    public string CigarDescription { get; }
    public InvalidCigarDescriptionException(string cigarDescription) 
        : base($"Cigar description '{cigarDescription}' is invalid.")
    {
        CigarDescription = cigarDescription;
    }
}