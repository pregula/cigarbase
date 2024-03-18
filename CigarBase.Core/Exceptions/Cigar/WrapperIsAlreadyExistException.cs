using CigarBase.Core.ValueObjects.Tobacco;

namespace CigarBase.Core.Exceptions.Cigar;

public sealed class WrapperIsAlreadyExistException : CustomException
{
    public TobaccoId TobaccoId { get; }
    public WrapperIsAlreadyExistException(TobaccoId tobaccoId)
        : base($"Tobacco used to wrapper with ID: {tobaccoId} is already exist.")
    {
        TobaccoId = tobaccoId;
    }
}