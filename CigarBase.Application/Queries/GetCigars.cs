using CigarBase.Application.Abstractions;
using CigarBase.Application.DTO;

namespace CigarBase.Application.Queries;

public class GetCigars : IQuery<IEnumerable<CigarDto>>
{
}