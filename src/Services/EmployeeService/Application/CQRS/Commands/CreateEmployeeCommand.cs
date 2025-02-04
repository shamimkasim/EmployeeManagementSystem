using EmployeeManagementSystem.Application.DTOs.Responses;
using MediatR;

namespace EmployeeManagementSystem.Application.CQRS.Commands
{
    public class CreateEmployeeCommand : IRequest<EmployeeResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DocumentNumber { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Role { get; set; }
        public Guid? ManagerId { get; set; }
        public string PasswordHash { get; set; }
    }
}
