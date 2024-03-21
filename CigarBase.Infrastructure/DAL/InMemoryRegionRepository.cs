using CigarBase.Core.Entities;
using CigarBase.Core.Repositories;
using CigarBase.Core.ValueObjects.Region;

namespace CigarBase.Infrastructure.DAL;

public class InMemoryRegionRepository : IRegionRepository
{
    private readonly List<Region> _regions;

    public InMemoryRegionRepository()
    {
        _regions = new()
        {
            new Region(Guid.Parse("00000000-0000-0000-0000-000000000001"), "Nicaragua"),
            new Region(Guid.Parse("00000000-0000-0000-0000-000000000002"), "Dominican Republic")
        };
    }
    public Task<Region> GetByIdAsync(RegionId regionId) => Task.FromResult(_regions.SingleOrDefault(r => r.Id == regionId));

    public Task<IEnumerable<Region>> SearchAsync() => Task.FromResult(_regions.AsEnumerable());
}