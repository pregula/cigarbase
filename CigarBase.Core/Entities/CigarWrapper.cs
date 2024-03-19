using CigarBase.Core.ValueObjects.Cigar;
using CigarBase.Core.ValueObjects.CigarTobaccoComponent;
using CigarBase.Core.ValueObjects.Region;

namespace CigarBase.Core.Entities;

public sealed class CigarWrapper : CigarTobaccoComponent
{
    public CigarWrapper(CigarTobaccoComponentId id, RegionId regionId, CigarId cigarId) 
        : base(id, regionId, cigarId)
    {
    }
}