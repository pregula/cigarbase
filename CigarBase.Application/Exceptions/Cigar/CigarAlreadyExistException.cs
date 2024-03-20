using CigarBase.Core.Exceptions;

namespace CigarBase.Application.Exceptions.Cigar;

public sealed class CigarAlreadyExistException : CustomException
{
    public string FullName { get; }
    public CigarAlreadyExistException(string fullName) : base($"Cigar: {fullName} already exist.")
    {
        FullName = fullName;
    }
}