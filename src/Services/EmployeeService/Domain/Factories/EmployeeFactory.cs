using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Enums;
using EmployeeManagementSystem.Domain.ValueObjects;
using EmployeeManagementSystem.Domain.Guards;
using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem.Domain.Factories
{
    public static class EmployeeFactory
    {
        public static Employee Create(string firstName, string lastName, string email, string documentNumber,
            List<PhoneNumber> phoneNumbers, DateTime dateOfBirth, EmployeeRole role, Guid? managerId)
        {
            // Apply Guard Clauses (DRY principle)
            Guard.AgainstNullOrEmpty(firstName, "First Name");
            Guard.AgainstNullOrEmpty(lastName, "Last Name");
            Guard.AgainstNullOrEmpty(email, "Email");
            Guard.AgainstEmailFormat(email, "Email");
            Guard.AgainstNullOrEmpty(documentNumber, "Document Number");
            Guard.AgainstUnderAge(dateOfBirth, 18, "Date of Birth");

            return new Employee(
                Guid.NewGuid(),
                firstName,
                lastName,
                email,
                documentNumber,
                phoneNumbers,
                dateOfBirth,
                role,
                managerId
            );
        }
    }
}
