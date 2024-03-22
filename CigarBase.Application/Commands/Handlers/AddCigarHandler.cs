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
        CigarBinder binder = null;
        if (command.WrapperIds is not null)
        {
            var tasks = command.WrapperIds.Select(w => _regionRepository.GetByIdAsync(w));
            var regions = await Task.WhenAll(tasks);
            var emptyRegion = command.WrapperIds.Where(w => !regions.Select(r => r.Id).ToList().Contains(w)).ToList();
            if (emptyRegion.Any())
            {
                throw new RegionIsNotExistException(emptyRegion.First());
            }

            wrappers = regions.Select(r => new CigarWrapper(Guid.NewGuid(), r.Id, cigarId)).ToList();
        }
        
        if (command.FillerIds is not null)
        {
            var tasks = command.FillerIds.Select(w => _regionRepository.GetByIdAsync(w));
            var regions = await Task.WhenAll(tasks);
            var emptyRegion = command.FillerIds.Where(f => !regions.Select(r => r.Id).ToList().Contains(f)).ToList();
            if (emptyRegion.Any())
            {
                throw new RegionIsNotExistException(emptyRegion.First());
            }

            fillers = regions.Select(r => new CigarFiller(Guid.NewGuid(), r.Id, cigarId)).ToList();
        }
        
        if (command.BinderId != Guid.Empty)
        {
            var region = await _regionRepository.GetByIdAsync(command.BinderId);
            if (region is null)
            {
                throw new RegionIsNotExistException(command.BinderId);
            }

            binder = new(Guid.NewGuid(), region.Id, cigarId);
        }

        if (await _cigarRepository.GetByNameAsync(fullName) is not null)
        {
            throw new CigarAlreadyExistException(fullName);
        }

        var cigar = Cigar.Create(cigarId, fullName, description, Date.Now());
        wrappers.ForEach(w => cigar.AddWrapper(w));
        fillers.ForEach(f => cigar.AddFiller(f));
        cigar.AddBinder(binder);
        await _cigarRepository.AddAsync(cigar);
    }
}