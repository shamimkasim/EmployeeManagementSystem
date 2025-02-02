using EmployeeManagementSystem.Application.CQRS.Commands;
using EmployeeManagementSystem.Application.DTOs.Responses;
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
            var employee = EmployeeFactory.Create(
                request.FirstName, request.LastName, request.Email, request.DocumentNumber,
                request.PhoneNumbers, request.DateOfBirth, request.Role, request.ManagerId);

            await _employeeRepository.AddAsync(employee);

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
