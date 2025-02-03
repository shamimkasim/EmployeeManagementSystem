//using System.Reflection;
//using EmployeeManagementSystem.Application.Interfaces;
//using EmployeeManagementSystem.Domain.Interfaces;
//using EmployeeManagementSystem.Infrastructure.Auth;
//using EmployeeManagementSystem.Infrastructure.Persistence;
//using EmployeeManagementSystem.Infrastructure.Persistence.Repositories;
//using EmployeeManagementSystem.Infrastructure.Security;
//using FluentValidation;
//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;

//namespace EmployeeManagementSystem.Infrastructure
//{
//    public static class InfrastructureDI
//    {
//        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
//        {
//            // Database Context
//            services.AddDbContext<AppDbContext>(options =>
//                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

//            // Repositories & Security Services
//            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
//            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
//            services.AddScoped<IPasswordHasher, PasswordHasher>();

//            // MediatR & FluentValidation - Using Application Assembly
//            services.AddMediatR(cfg =>
//            {
//                cfg.RequestExceptionActionProcessorStrategy = MediatR.RequestExceptionActionProcessorStrategy.ApplyForUnhandledExceptions;
//            }, Assembly.GetExecutingAssembly());

//            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

//            return services;
//        }
//    }
//}
