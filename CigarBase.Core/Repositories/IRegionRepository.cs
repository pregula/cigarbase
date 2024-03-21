using CigarBase.Core.Entities;
using CigarBase.Core.ValueObjects.Region;

namespace CigarBase.Core.Repositories;

public interface IRegionRepository
{
    Task<Region> GetByIdAsync(RegionId regionId);
    Task<IEnumerable<Region>> SearchAsync();
}