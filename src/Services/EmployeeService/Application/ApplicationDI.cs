using FluentValidation;
using EmployeeManagementSystem.Application.CQRS.Commands;
using EmployeeManagementSystem.Application.Validation;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace EmployeeManagementSystem.Application.IoC
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ApplicationDependencyInjection).Assembly);

            // Register FluentValidation
            services.AddValidatorsFromAssembly(typeof(ApplicationDependencyInjection).Assembly);

            return services;
        }
    }
}