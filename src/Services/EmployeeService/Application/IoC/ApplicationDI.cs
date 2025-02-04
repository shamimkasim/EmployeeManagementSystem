using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using EmployeeManagementSystem.Application.Services;
using EmployeeManagementSystem.Application.Interfaces;
using EmployeeManagementSystem.Application.Mappers;
using EmployeeManagementSystem.Application.Mappings;
using System.Reflection;
using EmployeeManagementSystem.Application.CQRS.Queries;
using EmployeeManagementSystem.Application.DTOs.Responses;
using EmployeeManagementSystem.Application.CQRS.Handlers;

namespace EmployeeManagementSystem.Application.IoC;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register MediatR for CQRS
        services.AddMediatR(typeof(ApplicationDependencyInjection).Assembly);

        // Register FluentValidation for Request Validation
        services.AddValidatorsFromAssembly(typeof(ApplicationDependencyInjection).Assembly);
        
            services.AddMediatR(cfg => cfg.AsSingleton(), Assembly.GetExecutingAssembly());

        //services.AddMediatR(cfg =>
        //{
        //    cfg.RequestExceptionActionProcessorStrategy = MediatR.RequestExceptionActionProcessorStrategy.ApplyForUnhandledExceptions;
        //}, Assembly.GetExecutingAssembly());
        services.AddScoped<IRequestHandler<GetAllEmployeesQuery, List<EmployeeResponse>>, GetAllEmployeesQueryHandler>();

        // Register AutoMapper for Object Mapping
        services.AddAutoMapper(typeof(EmployeeProfile)); // Add AutoMapper Profiles

        // Register Application Services
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}
