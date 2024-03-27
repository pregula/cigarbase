using CigarBase.Application.Abstractions;
using CigarBase.Application.Exceptions.Cigar;
using CigarBase.Core.Repositories;

namespace CigarBase.Application.Commands.Handlers;

public class DeleteCigarHandler : ICommandHandler<DeleteCigar>
{
    private readonly ICigarRepository _cigarRepository;

    public DeleteCigarHandler(ICigarRepository cigarRepository)
    {
        _cigarRepository = cigarRepository;
    }
    
    public async Task HandleAsync(DeleteCigar command)
    {
        var cigar = await _cigarRepository.GetAsync(command.CigarId);
        if (cigar is null)
        {
            throw new CigarNotFoundException(command.CigarId);
        }
        await _cigarRepository.DeleteAsync(cigar);
    }
}