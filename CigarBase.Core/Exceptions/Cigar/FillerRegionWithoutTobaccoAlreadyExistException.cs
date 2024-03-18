using CigarBase.Core.ValueObjects.Region;

namespace CigarBase.Core.Exceptions.Cigar;

public sealed class FillerRegionWithoutTobaccoAlreadyExistException : CustomException
{
    public RegionId RegionId { get; set; }
    public FillerRegionWithoutTobaccoAlreadyExistException(RegionId regionId)
        : base($"A filler region with ID: {regionId} already exists.")
    {
        RegionId = regionId;
    }
}