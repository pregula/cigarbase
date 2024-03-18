using CigarBase.Core.ValueObjects.Region;

namespace CigarBase.Core.Exceptions.Cigar;

public sealed class WrapperRegionWithoutTobaccoAlreadyExistException : CustomException
{
    public RegionId RegionId { get; set; }
    public WrapperRegionWithoutTobaccoAlreadyExistException(RegionId regionId)
        : base($"A wrapper region with ID: {regionId} already exists.")
    {
        RegionId = regionId;
    }
}