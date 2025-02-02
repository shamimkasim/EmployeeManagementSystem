using EmployeeManagementSystem.Application.DTOs.Responses;
using MediatR;

namespace EmployeeManagementSystem.Application.CQRS.Handlers
{
    public class UpdateEmployeeCommand : IRequest<EmployeeResponse>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<string> PhoneNumbers { get; set; }
        public string Role { get; set; }
    }
}