using EmployeeManagementSystem.Application.DTOs.Requests;
using FluentValidation;

namespace EmployeeManagementSystem.Application.Validators
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeRequest>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(e => e.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(e => e.LastName).NotEmpty().WithMessage("Last name is required.");
            RuleFor(e => e.Email).NotEmpty().EmailAddress().WithMessage("Invalid email format.");
            RuleFor(e => e.DocumentNumber).NotEmpty().WithMessage("Document number is required.");
            RuleFor(e => e.DateOfBirth).Must(date => date <= DateTime.UtcNow.AddYears(-18))
                .WithMessage("Employee must be at least 18 years old.");
        }
    }
}
