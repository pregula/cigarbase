using CigarBase.Application.Abstractions;

namespace CigarBase.Application.Commands;

public record AddCigar(Guid CigarId, string FullName, string Descritpion, Guid CountryId, Guid FactoryId,
    IEnumerable<Guid> WrapperIds, IEnumerable<Guid> FillerIds, Guid BinderId) : ICommand;