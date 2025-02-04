using EmployeeManagementSystem.Application.DTOs.Requests;
using EmployeeManagementSystem.Application.DTOs.Responses;
using EmployeeManagementSystem.Application.Interfaces;
using EmployeeManagementSystem.Domain.Factories;
using EmployeeManagementSystem.Domain.Interfaces;
using EmployeeManagementSystem.Domain.ValueObjects;

namespace EmployeeManagementSystem.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(
            IEmployeeRepository employeeRepository,
            IJwtTokenGenerator jwtTokenGenerator,
            IPasswordHasher passwordHasher)
        {
            _employeeRepository = employeeRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _passwordHasher = passwordHasher;
        }

        public async Task<AuthResponse> RegisterAsync(CreateEmployeeRequest request)
        {
            if (await _employeeRepository.GetByEmailAsync(request.Email) != null)
                throw new InvalidOperationException("Email is already in use.");

            var hashedPassword = _passwordHasher.HashPassword(request.Password);
            var phoneNumber = new PhoneNumber(request.PhoneNumber);

            // Check if Role exists
            var roleExists = await _employeeRepository.RoleExistsAsync(request.RoleId);
            if (!roleExists)
                throw new InvalidOperationException($"Role with ID {request.RoleId} does not exist.");

            var employee = EmployeeFactory.Create(
                request.FirstName,
                request.LastName,
                request.Email,
                request.DocumentNumber,
                phoneNumber,
                request.DateOfBirth,
                request.RoleId,
                request.ManagerId,
                hashedPassword
            );

            await _employeeRepository.AddAsync(employee);

            Console.WriteLine($"Employee Created: Id={employee?.Id}, Email={employee?.Email}, RoleId={employee?.RoleId}");

            if (employee == null || employee.Id == Guid.Empty || string.IsNullOrEmpty(employee.Email))
            {
                throw new NullReferenceException("Invalid Employee object before generating token.");
            }

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

            if (employee == null)
            {
                throw new UnauthorizedAccessException($"Invalid email or password. (Email: {request.Email} not found)");
            }

            if (!_passwordHasher.VerifyPassword(request.Password, employee.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid email or password. (Password verification failed)");
            }

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
