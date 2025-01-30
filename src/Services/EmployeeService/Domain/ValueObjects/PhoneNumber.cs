using System;

namespace EmployeeManagementSystem.Domain.ValueObjects
{
    public class PhoneNumber
    {
        public string Number { get; private set; }

        private PhoneNumber() { } // Required by EF Core

        public PhoneNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Phone number cannot be empty.");

            if (!IsValidPhoneNumber(number))
                throw new ArgumentException("Invalid phone number format.");

            Number = number;
        }

        private bool IsValidPhoneNumber(string number)
        {
            return number.Length >= 10 && number.Length <= 15;
        }

        public override string ToString() => Number;
    }
}
