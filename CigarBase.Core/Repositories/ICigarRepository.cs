using CigarBase.Core.Entities;
using CigarBase.Core.ValueObjects.Cigar;

namespace CigarBase.Core.Repositories;

public interface ICigarRepository
{
    Task<Cigar> GetAsync(CigarId id);
    Task<IEnumerable<Cigar>> SearchAsync();
    Task AddAsync(Cigar cigar);
    Task UpdateAsync(Cigar cigar);
    Task Delete(Cigar cigar);
}