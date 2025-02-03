using EmployeeManagementSystem.Application.DTOs.Responses;
using EmployeeManagementSystem.Application.DTOs.Requests;

namespace EmployeeManagementSystem.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeResponse> CreateEmployeeAsync(CreateEmployeeRequest request);
        Task<List<EmployeeResponse>> GetAllEmployeesAsync();
        Task<EmployeeResponse> GetEmployeeByIdAsync(Guid id);
        Task<EmployeeResponse> UpdateEmployeeAsync(UpdateEmployeeRequest request);
        Task DeleteAsync(Guid id);
    }
}
