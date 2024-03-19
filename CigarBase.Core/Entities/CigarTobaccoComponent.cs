#nullable enable
using CigarBase.Core.ValueObjects.Cigar;
using CigarBase.Core.ValueObjects.CigarTobaccoComponent;
using CigarBase.Core.ValueObjects.Region;
using CigarBase.Core.ValueObjects.Tobacco;

namespace CigarBase.Core.Entities;

public abstract class CigarTobaccoComponent
{
    public CigarTobaccoComponentId Id { get; private set; }
    // after deeper analysis, the tobacco region itself is enough for now
    // public TobaccoId? TobaccoId { get; private set; }
    public RegionId RegionId { get; private set; }
    public CigarId CigarId { get; private set; }

    public CigarTobaccoComponent(CigarTobaccoComponentId id, RegionId regionId, CigarId cigarId)
    {
        Id = id;
        RegionId = regionId;
        CigarId = cigarId;
    }
}