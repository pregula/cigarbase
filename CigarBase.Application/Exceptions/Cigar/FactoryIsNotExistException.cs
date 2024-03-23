using CigarBase.Core.Exceptions;

namespace CigarBase.Application.Exceptions.Cigar;

public sealed class FactoryIsNotExistException : CustomException
{
    public Guid FactoryId { get; private set; }
    public FactoryIsNotExistException(Guid factoryId) : base($"Factory with ID: {factoryId} is not exist.")
    {
        FactoryId = factoryId;
    }
}