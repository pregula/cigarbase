using CigarBase.Core.ValueObjects.Region;

namespace CigarBase.Core.Exceptions.Cigar;

public sealed class WrapperWithTheSameRegionIdAlreadyExistException : CustomException
{
    public RegionId RegionId { get; }
    public WrapperWithTheSameRegionIdAlreadyExistException(RegionId regionId)
        : base($"Wrapper with region ID: {regionId} already exist.")
    {
        RegionId = regionId;
    }
}