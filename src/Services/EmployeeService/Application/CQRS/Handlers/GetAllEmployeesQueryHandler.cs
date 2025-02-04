using EmployeeManagementSystem.Application.CQRS.Queries;
using EmployeeManagementSystem.Application.DTOs.Responses;
using EmployeeManagementSystem.Domain.Interfaces;
using MediatR;

namespace EmployeeManagementSystem.Application.CQRS.Handlers
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<EmployeeResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeResponse>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetAllAsync();

            return employees.Select(e => new EmployeeResponse
            {
                Id = e.Id,
                FirstName = e.FirstName ?? "N/A",
                LastName = e.LastName ?? "N/A",
                Email = e.Email ?? "N/A",
                DocumentNumber = e.DocumentNumber ?? "N/A",
                PhoneNumber = e.PhoneNumber?.ToString() ?? "N/A",
                Role = e.Role?.Name ?? "N/A", 
                CreatedAt = e.CreatedAt == default ? DateTime.UtcNow : e.CreatedAt,
                UpdatedAt = e.UpdatedAt
            }).ToList();
        }
    }

}