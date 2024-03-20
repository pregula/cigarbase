using CigarBase.Application.Abstractions;
using CigarBase.Application.Exceptions.Cigar;
using CigarBase.Core.Entities;
using CigarBase.Core.Repositories;
using CigarBase.Core.ValueObjects;
using CigarBase.Core.ValueObjects.Cigar;

namespace CigarBase.Application.Commands.Handlers;

public class AddCigarHandler : ICommandHandler<AddCigar>
{
    private readonly ICigarRepository _cigarRepository;

    public AddCigarHandler(ICigarRepository cigarRepository)
    {
        _cigarRepository = cigarRepository;
    }
    
    public async Task HandleAsync(AddCigar command)
    {
        var cigarId = new CigarId(command.CigarId);
        var fullName = new CigarFullName(command.FullName);
        var description = new CigarDescription(command.Descritpion);
        if (command.WrapperIds.Any())
        {
            // todo
        }

        if (await _cigarRepository.GetByNameAsync(fullName) is not null)
        {
            throw new CigarAlreadyExistException(fullName);
        }

        var cigar = Cigar.Create(cigarId, fullName, description, Date.Now());

        await _cigarRepository.AddAsync(cigar);
    }
}