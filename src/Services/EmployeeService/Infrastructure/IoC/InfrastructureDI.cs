using System.Reflection;
using EmployeeManagementSystem.Application.Interfaces;
using EmployeeManagementSystem.Domain.Interfaces;
using EmployeeManagementSystem.Infrastructure.Auth;
using EmployeeManagementSystem.Infrastructure.Persistence;
using EmployeeManagementSystem.Infrastructure.Persistence.Repositories;
using EmployeeManagementSystem.Infrastructure.Security;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagementSystem.Infrastructure.IoC;

public static class InfrastructureDI
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();

        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg =>
        {
            cfg.RequestExceptionActionProcessorStrategy = MediatR.RequestExceptionActionProcessorStrategy.ApplyForUnhandledExceptions;
        }, Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
