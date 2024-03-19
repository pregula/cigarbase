using CigarBase.Core.ValueObjects.Tobacco;

namespace CigarBase.Core.Exceptions.Cigar;

public sealed class FillerAlreadyExistException : CustomException
{
    public TobaccoId TobaccoId { get; }
    public FillerAlreadyExistException(TobaccoId tobaccoId)
        : base($"Tobacco used as filler with ID: {tobaccoId} already exist.")
    {
        TobaccoId = tobaccoId;
    }
}