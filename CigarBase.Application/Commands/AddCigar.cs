using CigarBase.Application.Abstractions;

namespace CigarBase.Application.Commands;

public record AddCigar(Guid CigarId, string FullName, string Descritpion, IEnumerable<Guid> WrapperIds) : ICommand;