using CigarBase.Application.DTO;
using CigarBase.Core.Entities;

namespace CigarBase.Infrastructure.DAL.Handlers;

internal static class Extensions
{
    public static CigarDto AsDto(this Cigar entity)
        => new()
        {
            Id = entity.Id.ToString(),
            Name = entity.FullName
        };
}