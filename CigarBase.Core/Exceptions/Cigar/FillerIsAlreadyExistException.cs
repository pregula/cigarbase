using CigarBase.Core.ValueObjects.Tobacco;

namespace CigarBase.Core.Exceptions.Cigar;

public sealed class FillerIsAlreadyExistException : CustomException
{
    public TobaccoId TobaccoId { get; }
    public FillerIsAlreadyExistException(TobaccoId tobaccoId)
        : base($"Tobacco used to filler with ID: {tobaccoId} is already exist.")
    {
        TobaccoId = tobaccoId;
    }
}