using EmployeeManagementSystem.Application.DTOs.Responses;
using EmployeeManagementSystem.Domain.Enums;
using EmployeeManagementSystem.Domain.Helpers;
using EmployeeManagementSystem.Domain.Interfaces;
using EmployeeManagementSystem.Domain.ValueObjects;
using MediatR;

namespace EmployeeManagementSystem.Application.CQRS.Handlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id);
            if (employee == null)
                throw new KeyNotFoundException("Employee not found.");

            var phoneNumber = new PhoneNumber(request.PhoneNumber);
            Guid roleId = RoleHelper.GetRoleIdFromEnum((EmployeeRole)Enum.Parse(typeof(EmployeeRole), request.Role));



            employee.Update(
             request.FirstName,
             request.LastName,
             phoneNumber,
             roleId
         );


            await _employeeRepository.UpdateAsync(employee);

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
