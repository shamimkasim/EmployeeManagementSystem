using EmployeeManagementSystem.Application.DTOs.Requests;
using EmployeeManagementSystem.Application.DTOs.Responses;

namespace EmployeeManagementSystem.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> LoginAsync(LoginRequest request);
        Task<AuthResponse> RegisterAsync(CreateEmployeeRequest request);
    }
}
