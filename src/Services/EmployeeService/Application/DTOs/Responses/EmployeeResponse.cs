using EmployeeManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem.Application.DTOs.Responses
{
    public class EmployeeResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public EmployeeRole Role { get; set; }
        public List<string> PhoneNumbers { get; set; }
    }
}
