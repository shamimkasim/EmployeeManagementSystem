using EmployeeManagementSystem.Application.DTOs.Requests;
using EmployeeManagementSystem.Application.DTOs.Responses;
using EmployeeManagementSystem.Application.Interfaces;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Factories;
using EmployeeManagementSystem.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(IEmployeeRepository employeeRepository, IJwtTokenGenerator jwtTokenGenerator, IPasswordHasher passwordHasher)
        {
            _employeeRepository = employeeRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _passwordHasher = passwordHasher;
        }

        public async Task<AuthResponse> RegisterAsync(CreateEmployeeRequest request)
        {
            var hashedPassword = _passwordHasher.HashPassword(request.Password);

            var employee = EmployeeFactory.Create(
                request.FirstName, request.LastName, request.Email, request.DocumentNumber,
                request.PhoneNumbers, request.DateOfBirth, request.Role, request.ManagerId
            );

            await _employeeRepository.AddAsync(employee);

            var token = _jwtTokenGenerator.GenerateToken(employee);

            return new AuthResponse
            {
                Token = token,
                UserId = employee.Id,
                Email = employee.Email
            };
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var employee = await _employeeRepository.GetByEmailAsync(request.Email);
            if (employee == null || !_passwordHasher.VerifyPassword(request.Password, employee.PasswordHash))
                throw new UnauthorizedAccessException("Invalid email or password.");

            var token = _jwtTokenGenerator.GenerateToken(employee);

            return new AuthResponse
            {
                Token = token,
                UserId = employee.Id,
                Email = employee.Email
            };
        }
    }
}
