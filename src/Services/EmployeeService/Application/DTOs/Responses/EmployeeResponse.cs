using System;

namespace EmployeeManagementSystem.Application.DTOs.Responses
{
    public class EmployeeResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string DocumentNumber { get; set; }
    public string PhoneNumber { get; set; }
    public string Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
 }

}
