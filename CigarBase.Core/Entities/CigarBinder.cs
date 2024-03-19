using CigarBase.Core.ValueObjects.Cigar;
using CigarBase.Core.ValueObjects.CigarTobaccoComponent;
using CigarBase.Core.ValueObjects.Region;

namespace CigarBase.Core.Entities;

public sealed class CigarBinder : CigarTobaccoComponent
{
    public CigarBinder(CigarTobaccoComponentId id, RegionId regionId, CigarId cigarId) 
        : base(id, regionId, cigarId)
    {
    }
}