using System.Reflection;
using EmployeeManagementSystem.Application.CQRS.Handlers;
using EmployeeManagementSystem.Application.CQRS.Queries;
using EmployeeManagementSystem.Application.DTOs.Responses;
using EmployeeManagementSystem.Application.Interfaces;
using EmployeeManagementSystem.Application.Mappings;
using EmployeeManagementSystem.Application.Services;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagementSystem.Application.IoC;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddMediatR(typeof(ApplicationDependencyInjection).Assembly);

        services.AddValidatorsFromAssembly(typeof(ApplicationDependencyInjection).Assembly);

        services.AddMediatR(cfg => cfg.AsSingleton(), Assembly.GetExecutingAssembly());

        services.AddScoped<IRequestHandler<GetAllEmployeesQuery, List<EmployeeResponse>>, GetAllEmployeesQueryHandler>();
        services.AddAutoMapper(typeof(EmployeeProfile));
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}
