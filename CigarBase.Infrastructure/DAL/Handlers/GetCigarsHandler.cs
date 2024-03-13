using CigarBase.Application.Abstractions;
using CigarBase.Application.DTO;
using CigarBase.Application.Queries;
using CigarBase.Core.Repositories;

namespace CigarBase.Infrastructure.DAL.Handlers;

internal sealed class GetCigarsHandler : IQueryHandler<GetCigars, IEnumerable<CigarDto>>
{
    private readonly ICigarRepository _repository;

    public GetCigarsHandler(ICigarRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CigarDto>> HandleAsync(GetCigars query)
    {
        return (await _repository.SearchAsync())
            .Select(c => c.AsDto());
    }
}