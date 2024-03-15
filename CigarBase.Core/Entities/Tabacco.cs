using CigarBase.Core.ValueObjects.Tobacco;

namespace CigarBase.Core.Entities;

public sealed class Tobacco
{
    public TobaccoId Id { get; private set; }
    public TobaccoName Name { get; private set; }
} 