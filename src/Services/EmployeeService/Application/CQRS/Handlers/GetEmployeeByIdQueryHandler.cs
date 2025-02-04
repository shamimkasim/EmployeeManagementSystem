using EmployeeManagementSystem.Application.DTOs.Responses;
using EmployeeManagementSystem.Domain.Interfaces;
using MediatR;

namespace EmployeeManagementSystem.Application.CQRS.Handlers
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeResponse> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.EmployeeId);

            if (employee == null)
                throw new KeyNotFoundException($"Employee with ID {request.EmployeeId} not found.");

            return new EmployeeResponse
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                DocumentNumber = employee.DocumentNumber,
                PhoneNumber = employee.PhoneNumber.ToString(),
                Role = employee.Role.Name,
                CreatedAt = employee.CreatedAt,
                UpdatedAt = employee.UpdatedAt
            };
        }
    }
}
