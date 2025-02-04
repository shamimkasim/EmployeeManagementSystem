using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.Enums;
using EmployeeManagementSystem.Domain.ValueObjects;
using EmployeeManagementSystem.Domain.Guards;
using EmployeeManagementSystem.Domain.Helpers;
using System;

namespace EmployeeManagementSystem.Domain.Factories;

public static class EmployeeFactory
{
    public static Employee Create(string firstName, string lastName, string email, string documentNumber,
        PhoneNumber phoneNumber, DateTime dateOfBirth, Guid roleId, Guid? managerId, string passwordHash)
    {
        Guard.AgainstNullOrEmpty(firstName, "First Name");
        Guard.AgainstNullOrEmpty(lastName, "Last Name");
        Guard.AgainstNullOrEmpty(email, "Email");
        Guard.AgainstEmailFormat(email, "Email");
        Guard.AgainstNullOrEmpty(documentNumber, "Document Number");
        Guard.AgainstUnderAge(dateOfBirth, 18, "Date of Birth");
        Guard.AgainstNullOrEmpty(passwordHash, "Password Hash");

        return new Employee(
            Guid.NewGuid(),
            firstName,
            lastName,
            email,
            documentNumber,
            phoneNumber
            ,
            dateOfBirth,
            roleId,  
            managerId,
            passwordHash
        );
    }
}
