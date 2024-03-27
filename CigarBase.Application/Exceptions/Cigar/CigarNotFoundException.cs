using CigarBase.Core.Exceptions;

namespace CigarBase.Application.Exceptions.Cigar;

public sealed class CigarNotFoundException : CustomException
{
    public Guid Id { get; }
    public CigarNotFoundException(Guid id) : base($"Cigar with ID: {id} was not found.")
    {
        Id = id;
    }
}