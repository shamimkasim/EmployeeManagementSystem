using System;
using EmployeeManagementSystem.Domain.ValueObjects;

namespace EmployeeManagementSystem.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string DocumentNumber { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }   
        public Guid RoleId { get; private set; }
        public Guid? ManagerId { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public string PasswordHash { get; private set; }

         
        public Role Role { get; private set; }

        private Employee() { }  

        public Employee(Guid id, string firstName, string lastName, string email, string documentNumber,
            PhoneNumber phoneNumber, DateTime dateOfBirth, Guid roleId, Guid? managerId, string passwordHash)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DocumentNumber = documentNumber;
            PhoneNumber = phoneNumber;   
            DateOfBirth = dateOfBirth;
            RoleId = roleId;
            ManagerId = managerId;
            CreatedAt = DateTime.UtcNow;
            PasswordHash = passwordHash;
        }

        public void Update(string firstName, string lastName, PhoneNumber phoneNumber, Guid roleId)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;   
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
