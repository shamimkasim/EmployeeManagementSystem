namespace EmployeeManagementSystem.Application.DTOs.Responses
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public Guid UserId { get; set; }
        public string Email { get; set; }
    }
}
