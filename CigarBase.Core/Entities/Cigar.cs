using CigarBase.Core.ValueObjects.Cigar;

namespace CigarBase.Core.Entities;

public sealed class Cigar
{
    public CigarId Id { get; private set; }
    public CigarName Name { get; private set; }
    public CigarDescription Description { get; private set; }
    private readonly HashSet<Rating> _ratings = new();
    public IEnumerable<Rating> Ratings => _ratings;
}