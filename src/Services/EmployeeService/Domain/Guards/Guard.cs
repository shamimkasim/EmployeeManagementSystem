using System;
using System.Text.RegularExpressions;

namespace EmployeeManagementSystem.Domain.Guards
{
    public static class Guard
    {
        public static void AgainstNullOrEmpty(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"{fieldName} cannot be empty.");
        }

        public static void AgainstEmailFormat(string email, string fieldName)
        {
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException($"{fieldName} is not a valid email.");
        }

        public static void AgainstUnderAge(DateTime birthDate, int minAge, string fieldName)
        {
            if (birthDate > DateTime.UtcNow.AddYears(-minAge))
                throw new ArgumentException($"{fieldName} must be at least {minAge} years old.");
        }
    }
}
