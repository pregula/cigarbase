using CigarBase.Application.Abstractions;

namespace CigarBase.Application.Commands;

public record DeleteCigar(Guid CigarId) : ICommand;