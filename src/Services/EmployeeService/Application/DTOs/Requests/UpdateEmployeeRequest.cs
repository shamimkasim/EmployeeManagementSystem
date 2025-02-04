using EmployeeManagementSystem.Domain.Enums;
using EmployeeManagementSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem.Application.DTOs.Requests
{
    public class UpdateEmployeeRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public EmployeeRole Role { get; set; }
    }
}
