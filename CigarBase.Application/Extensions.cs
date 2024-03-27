using CigarBase.Application.Abstractions;
using CigarBase.Application.Commands;
using CigarBase.Application.Commands.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace CigarBase.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICommandHandler<AddCigar>, AddCigarHandler>();
        services.AddScoped<ICommandHandler<DeleteCigar>, DeleteCigarHandler>();
        return services;
    }
}