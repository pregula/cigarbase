using CigarBase.Core.ValueObjects.Factory;

namespace CigarBase.Core.Entities;

public sealed class Factory
{
    public FactoryId Id { get; private set; }
    public FactoryName Name { get; private set; }
    private Factory(FactoryId id, FactoryName name)
    {
        Id = id;
        Name = name;
    }

    public static Factory Create(FactoryId factoryId, FactoryName factoryName)
        => new(factoryId, factoryName);
}