using EmployeeManagementSystem.Application.CQRS.Commands;
using EmployeeManagementSystem.Application.DTOs.Responses;
using EmployeeManagementSystem.Domain.Enums;
using EmployeeManagementSystem.Domain.Factories;
using EmployeeManagementSystem.Domain.Helpers;
using EmployeeManagementSystem.Domain.Interfaces;
using EmployeeManagementSystem.Domain.ValueObjects;
using MediatR;

namespace EmployeeManagementSystem.Application.CQRS.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var phoneNumber = new PhoneNumber(request.PhoneNumber);
            var role = (EmployeeRole)Enum.Parse(typeof(EmployeeRole), request.Role);

            Guid roleId = RoleHelper.GetRoleIdFromEnum(role);  

            var employee = EmployeeFactory.Create(
                request.FirstName,
                request.LastName,
                request.Email,
                request.DocumentNumber,
                phoneNumber,
                request.DateOfBirth,
                roleId,   
                request.ManagerId,
                request.PasswordHash
            );

            await _employeeRepository.AddAsync(employee);

            return new EmployeeResponse
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                DocumentNumber = employee.DocumentNumber,
                PhoneNumber = employee.PhoneNumber.ToString(),
                Role = employee.Role.ToString(),   
                CreatedAt = employee.CreatedAt,
                UpdatedAt = employee.UpdatedAt
            };
        }
    }
}
