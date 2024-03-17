using CigarBase.Core.ValueObjects.Region;

namespace CigarBase.Core.Entities;

public sealed class Region
{
    public RegionId Id { get; private set; }
    public RegionName Name { get; private set; }
}