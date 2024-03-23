using CigarBase.Core.Entities;
using CigarBase.Core.Repositories;
using CigarBase.Core.ValueObjects.Factory;

namespace CigarBase.Infrastructure.DAL;

internal class InMemoryFactoryRepository : IFactoryRepository
{
    private readonly List<Factory> _factoryList;

    public InMemoryFactoryRepository()
    {
        _factoryList = new()
        {
            Factory.Create(Guid.Parse("00000000-0000-0000-0000-000000000001"), "Rocky Patel"),
            Factory.Create(Guid.Parse("00000000-0000-0000-0000-000000000002"), "Horacio")
        };
    }
    
    public Task<Factory> GetByIdAsync(FactoryId factoryId) 
        => Task.FromResult(_factoryList.SingleOrDefault(f => f.Id == factoryId));

    public Task<IEnumerable<Factory>> SearchAsync() 
        => Task.FromResult(_factoryList.AsEnumerable());
}