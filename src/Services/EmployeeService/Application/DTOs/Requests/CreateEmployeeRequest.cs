using EmployeeManagementSystem.Domain.Enums;
using EmployeeManagementSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem.Application.DTOs.Requests
{
    public class CreateEmployeeRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DocumentNumber { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public DateTime DateOfBirth { get; set; }
        public EmployeeRole Role { get; set; }
        public Guid? ManagerId { get; set; }
    }
}
