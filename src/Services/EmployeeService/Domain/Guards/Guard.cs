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

        public static void AgainstNull(object value, string fieldName)
        {
            if (value == null)
                throw new ArgumentNullException(fieldName, $"{fieldName} cannot be null.");
        }

        public static void AgainstEmailFormat(string email, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(email) ||
                !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                throw new ArgumentException($"{fieldName} is not a valid email address.");
            }
        }
        public static void AgainstUnderAge(DateTime birthDate, int minAge, string fieldName)
        {
            if (birthDate > DateTime.UtcNow.AddYears(-minAge))
                throw new ArgumentException($"{fieldName} must be at least {minAge} years old.");
        }
        public static void AgainstInvalidPhoneNumber(string phoneNumber, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber) ||
                !Regex.IsMatch(phoneNumber, @"^\+?[1-9]\d{9,14}$"))
            {
                throw new ArgumentException($"{fieldName} is not a valid phone number.");
            }
        }
        public static void AgainstNegativeOrZero(decimal value, string fieldName)
        {
            if (value <= 0)
                throw new ArgumentException($"{fieldName} must be greater than zero.");
        }

        public static void AgainstInvalidDate(DateTime date, string fieldName)
        {
            if (date > DateTime.UtcNow)
                throw new ArgumentException($"{fieldName} cannot be in the future.");
        }
    }
}
