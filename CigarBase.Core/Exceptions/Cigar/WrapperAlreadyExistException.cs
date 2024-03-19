using CigarBase.Core.ValueObjects.Tobacco;

namespace CigarBase.Core.Exceptions.Cigar;

public sealed class WrapperAlreadyExistException : CustomException
{
    public TobaccoId TobaccoId { get; }
    public WrapperAlreadyExistException(TobaccoId tobaccoId)
        : base($"Tobacco used to wrapper with ID: {tobaccoId} already exist.")
    {
        TobaccoId = tobaccoId;
    }
}