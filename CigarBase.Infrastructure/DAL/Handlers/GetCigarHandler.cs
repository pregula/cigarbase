using CigarBase.Application.Abstractions;
using CigarBase.Application.DTO;
using CigarBase.Application.Queries;
using CigarBase.Core.Repositories;

namespace CigarBase.Infrastructure.DAL.Handlers;

internal sealed class GetCigarHandler : IQueryHandler<GetCigar, CigarDetailsDto>
{
    private readonly ICigarRepository _repository;
    public GetCigarHandler(ICigarRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<CigarDetailsDto> HandleAsync(GetCigar query)
    {
        return (await _repository.GetAsync(query.CigarId)).AsDetailsDto();
    }
}