using System.Text.RegularExpressions;

namespace EmployeeManagementSystem.Domain.ValueObjects
{
    public class PhoneNumber
    {
        private static readonly Regex PhoneNumberRegex = new(@"^\+?\d{7,15}$");
        public string Number { get; private set; }

        public PhoneNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Phone number cannot be empty.");

            if (!PhoneNumberRegex.IsMatch(number))
                throw new ArgumentException("Invalid phone number format.");

            Number = number;
        }
        public override string ToString() => Number;
    }
}
