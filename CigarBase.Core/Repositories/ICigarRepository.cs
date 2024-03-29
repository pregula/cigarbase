using CigarBase.Core.Entities;
using CigarBase.Core.ValueObjects.Cigar;

namespace CigarBase.Core.Repositories;

public interface ICigarRepository
{
    Task<Cigar> GetAsync(CigarId id);
    Task<Cigar> GetByNameAsync(CigarFullName fullName);
    Task<IEnumerable<Cigar>> SearchAsync();
    Task AddAsync(Cigar cigar);
    Task UpdateAsync(Cigar cigar);
    Task DeleteAsync(Cigar cigar);
}