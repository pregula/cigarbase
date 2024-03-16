using CigarBase.Application.Abstractions;
using CigarBase.Application.DTO;

namespace CigarBase.Application.Queries;

public class GetCigar : IQuery<CigarDetailsDto>
{
    public Guid CigarId { get; set; }
}