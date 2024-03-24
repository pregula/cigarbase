using CigarBase.Application.Abstractions;
using CigarBase.Application.Exceptions.Cigar;
using CigarBase.Core.Entities;
using CigarBase.Core.Repositories;
using CigarBase.Core.ValueObjects;
using CigarBase.Core.ValueObjects.Cigar;
using CigarBase.Core.ValueObjects.CigarTobaccoComponent;
using CigarBase.Core.ValueObjects.Factory;
using CigarBase.Core.ValueObjects.Region;

namespace CigarBase.Application.Commands.Handlers;

public class AddCigarHandler : ICommandHandler<AddCigar>
{
    private readonly ICigarRepository _cigarRepository;
    private readonly IRegionRepository _regionRepository;
    private readonly IFactoryRepository _factoryRepository;

    public AddCigarHandler(ICigarRepository cigarRepository,
        IRegionRepository regionRepository,
        IFactoryRepository factoryRepository)
    {
        _cigarRepository = cigarRepository;
        _regionRepository = regionRepository;
        _factoryRepository = factoryRepository;
    }
    
    public async Task HandleAsync(AddCigar command)
    {
        var cigarId = new CigarId(command.CigarId);
        var fullName = new CigarFullName(command.FullName);
        var description = new CigarDescription(command.Descritpion);
        var countryId = new RegionId(command.CountryId);
        var factoryId = new FactoryId(command.FactoryId);
        
        var country = await _regionRepository.GetByIdAsync(countryId);
        if (country is null)
        {
            throw new RegionIsNotExistException(countryId);
        }

        var factory = await _factoryRepository.GetByIdAsync(factoryId);
        if (factory is null)
        {
            throw new FactoryIsNotExistException(factoryId);
        }
        
        List<CigarWrapper> wrappers = new();
        List<CigarFiller> fillers = new();
        CigarBinder binder = null;
        
        if (command.WrapperIds is not null)
        {
            wrappers = await CheckAndAddCigarComponentListAsync(command.WrapperIds, cigarId,
                (baseComponentId, baseRegionId, baseCigarId) => new CigarWrapper(baseComponentId, baseRegionId, baseCigarId));
        }
        
        if (command.FillerIds is not null)
        {
            fillers = await CheckAndAddCigarComponentListAsync(command.FillerIds, cigarId,
                (baseComponentId, baseRegionId, baseCigarId) => new CigarFiller(baseComponentId, baseRegionId, baseCigarId));
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

        var cigar = Cigar.Create(cigarId, fullName, description, countryId, factoryId, Date.Now());
        wrappers.ForEach(w => cigar.AddWrapper(w));
        fillers.ForEach(f => cigar.AddFiller(f));
        cigar.AddBinder(binder);
        await _cigarRepository.AddAsync(cigar);
    }

    private async Task<List<T>> CheckAndAddCigarComponentListAsync<T>(IEnumerable<Guid> cigarComponentIds, Guid cigarId, Func<CigarTobaccoComponentId, RegionId, CigarId, T> constructor) where T : CigarTobaccoComponent
    {
        var tasks = cigarComponentIds.Select(w => _regionRepository.GetByIdAsync(w));
        var regions = await Task.WhenAll(tasks);
        var emptyRegionIds = cigarComponentIds.Where(w => !regions.Select(r => r.Id).ToList().Contains(w)).ToList();
        if (emptyRegionIds.Any())
        {
            throw new RegionIsNotExistException(emptyRegionIds.First());
        }

        return regions.Select(r => constructor(Guid.NewGuid(), r.Id, cigarId)).ToList();
    }
}