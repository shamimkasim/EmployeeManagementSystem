using EmployeeManagementSystem.Application.CQRS.Commands;
using EmployeeManagementSystem.Application.DTOs.Responses;
using EmployeeManagementSystem.Application.Interfaces;
using EmployeeManagementSystem.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EmployeeManagementSystem.Application.CQRS.Commands;

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

            employee.Update(request.FirstName, request.LastName, request.PhoneNumbers, request.Role);
            await _employeeRepository.UpdateAsync(employee);

            return new EmployeeResponse
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Role = employee.Role,
                PhoneNumbers = employee.PhoneNumbers.ConvertAll(p => p.ToString())
            };
        }
    }
}
