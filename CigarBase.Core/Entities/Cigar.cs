using CigarBase.Core.ValueObjects;

namespace CigarBase.Core.Entities;

public sealed class Cigar
{
    public CigarId Id { get; private set; }
    private readonly HashSet<Rating> _ratings = new();
    public IEnumerable<Rating> Ratings => _ratings;
}