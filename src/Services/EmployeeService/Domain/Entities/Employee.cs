using EmployeeManagementSystem.Domain.Enums;
using EmployeeManagementSystem.Domain.ValueObjects;
using EmployeeManagementSystem.Domain.Guards;
using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string DocumentNumber { get; private set; }
        public List<PhoneNumber> PhoneNumbers { get; private set; }
        public Guid? ManagerId { get; private set; }
        public EmployeeRole Role { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        // Private constructor (forces usage of Factory)
        private Employee() { }

        // Internal constructor for Factory
        internal Employee(Guid id, string firstName, string lastName, string email, string documentNumber,
            List<PhoneNumber> phoneNumbers, DateTime dateOfBirth, EmployeeRole role, Guid? managerId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DocumentNumber = documentNumber;
            PhoneNumbers = phoneNumbers;
            DateOfBirth = dateOfBirth;
            Role = role;
            ManagerId = managerId;
            CreatedAt = DateTime.UtcNow;
        }

        public void Update(string firstName, string lastName, List<PhoneNumber> phoneNumbers, EmployeeRole role)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumbers = phoneNumbers;
            Role = role;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
