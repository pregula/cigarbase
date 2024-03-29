using CigarBase.Core.Entities;
using CigarBase.Core.Repositories;
using CigarBase.Core.ValueObjects;
using CigarBase.Core.ValueObjects.Cigar;

namespace CigarBase.Infrastructure.DAL;

internal class InMemoryCigarRepository : ICigarRepository
{
    private readonly List<Cigar> _cigarList;

    public InMemoryCigarRepository()
    {
        _cigarList = new()
        {
            Cigar.Create(Guid.Parse("00000000-0000-0000-0000-000000000001"), "Rocky Patel SIXTY Anniversary Sixty", "Description Rocky Patel SIXTY...",  Guid.Parse("00000000-0000-0000-0000-000000000001"), Guid.Parse("00000000-0000-0000-0000-000000000001"),Date.Now()),
            Cigar.Create(Guid.Parse("00000000-0000-0000-0000-000000000002"), "Horacio Sled Edicion Especial", "Description Horacio Sled...", Guid.Parse("00000000-0000-0000-0000-000000000002"),Guid.Parse("00000000-0000-0000-0000-000000000002"), Date.Now())
        };
    }
    public Task<Cigar> GetAsync(CigarId id) 
        => Task.FromResult(_cigarList.SingleOrDefault(c => c.Id == id));

    public Task<Cigar> GetByNameAsync(CigarFullName fullName) 
        => Task.FromResult(_cigarList.SingleOrDefault(c => c.FullName == fullName));

    public Task<IEnumerable<Cigar>> SearchAsync() 
        => Task.FromResult(_cigarList.AsEnumerable());

    public Task AddAsync(Cigar cigar)
    {
        _cigarList.Add(cigar);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Cigar cigar)
    {
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Cigar cigar)
    {
        _cigarList.Remove(cigar);
        return Task.CompletedTask;
    }
}