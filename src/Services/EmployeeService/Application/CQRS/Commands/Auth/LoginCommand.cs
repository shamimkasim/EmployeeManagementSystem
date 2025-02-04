using EmployeeManagementSystem.Application.DTOs.Responses;
using MediatR;

namespace EmployeeManagementSystem.Application.CQRS.Commands.Auth
{
    public class LoginCommand : IRequest<AuthResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
