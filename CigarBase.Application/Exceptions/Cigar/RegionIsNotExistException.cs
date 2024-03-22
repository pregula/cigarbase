using CigarBase.Core.Exceptions;

namespace CigarBase.Application.Exceptions.Cigar;

public sealed class RegionIsNotExistException : CustomException
{
    public Guid Id { get; }
    public RegionIsNotExistException(Guid id) : base($"Region with ID: {id} is not exist.")
    {
        Id = id;
    }
}