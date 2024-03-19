using CigarBase.Core.ValueObjects.Region;

namespace CigarBase.Core.Exceptions.Cigar;

public sealed class FillerWithTheSameRegionIdAlreadyExistException : CustomException
{
    public RegionId RegionId { get; }
    public FillerWithTheSameRegionIdAlreadyExistException(RegionId regionId)
        : base($"Filler with region ID: {regionId} already exist.")
    {
        RegionId = regionId;
    }
}