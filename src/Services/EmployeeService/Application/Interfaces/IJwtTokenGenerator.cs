namespace EmployeeManagementSystem.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Employee employee);
    }
}
