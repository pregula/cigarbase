using CigarBase.Core.ValueObjects.Cigar;
using CigarBase.Core.ValueObjects.CigarTobaccoComponent;
using CigarBase.Core.ValueObjects.Region;
using CigarBase.Core.ValueObjects.Tobacco;

namespace CigarBase.Core.Entities;

public sealed class CigarFiller : CigarTobaccoComponent
{
    public CigarFiller(CigarTobaccoComponentId id, TobaccoId tobaccoId, RegionId regionId, CigarId cigarId) 
        : base(id, tobaccoId, regionId, cigarId)
    {
    }
}