using EmployeeManagementSystem.Application.Interfaces;
using EmployeeManagementSystem.Domain.Interfaces;
using EmployeeManagementSystem.Infrastructure.Auth;
using EmployeeManagementSystem.Infrastructure.Persistence;
using EmployeeManagementSystem.Infrastructure.Persistence.Repositories;
using EmployeeManagementSystem.Infrastructure.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagementSystem.Infrastructure.IoC
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationDI).Assembly));
            //services.AddValidatorsFromAssembly(typeof(ApplicationDI).Assembly);

            return services;
        }
    }
}

