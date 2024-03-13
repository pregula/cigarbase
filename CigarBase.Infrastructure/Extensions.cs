using CigarBase.Application.Abstractions;
using CigarBase.Application.DTO;
using CigarBase.Application.Queries;
using CigarBase.Core.Repositories;
using CigarBase.Infrastructure.DAL;
using CigarBase.Infrastructure.DAL.Handlers;
using CigarBase.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CigarBase.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ExceptionMiddleware>();
        services.AddSingleton<ICigarRepository, InMemoryCigarRepository>();
        services.AddScoped<IQueryHandler<GetCigars, IEnumerable<CigarDto>>, GetCigarsHandler>();
        services.AddControllers();
        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.MapControllers();
        return app;
    }
}