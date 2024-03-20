using CigarBase.Application;
using CigarBase.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();
app.UseInfrastructure();
app.Run();