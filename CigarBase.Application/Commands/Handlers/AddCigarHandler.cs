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
    private readonly IRegionRepository _regionRepository;

    public AddCigarHandler(ICigarRepository cigarRepository, IRegionRepository regionRepository)
    {
        _cigarRepository = cigarRepository;
        _regionRepository = regionRepository;
    }
    
    public async Task HandleAsync(AddCigar command)
    {
        var cigarId = new CigarId(command.CigarId);
        var fullName = new CigarFullName(command.FullName);
        var description = new CigarDescription(command.Descritpion);
        List<CigarWrapper> wrappers = new();
        List<CigarFiller> fillers = new();
        if (command.WrapperIds is not null)
        {
            var tasks = command.WrapperIds.Select(w => _regionRepository.GetByIdAsync(w));
            var regions = await Task.WhenAll(tasks);
            var emptyRegion = regions.Where(r => r is null);
            if (emptyRegion.Any())
            {
                // todo

                throw new Exception();
            }

            wrappers = regions.Select(r => new CigarWrapper(Guid.NewGuid(), r.Id, cigarId)).ToList();
        }
        
        if (command.FillerIds is not null)
        {
            // todo
        }
        
        if (command.BinderId != Guid.Empty)
        {
            // todo
        }

        if (await _cigarRepository.GetByNameAsync(fullName) is not null)
        {
            throw new CigarAlreadyExistException(fullName);
        }

        var cigar = Cigar.Create(cigarId, fullName, description, Date.Now());
        wrappers.ForEach(w => cigar.AddWrapper(w));

        await _cigarRepository.AddAsync(cigar);
    }
}