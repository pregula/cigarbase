using CigarBase.Core.Entities;
using CigarBase.Core.ValueObjects.Factory;

namespace CigarBase.Core.Repositories;

public interface IFactoryRepository
{
    Task<Factory> GetByIdAsync(FactoryId factoryId);
    Task<IEnumerable<Factory>> SearchAsync();
}