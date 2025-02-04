using EmployeeManagementSystem.Application.DTOs.Requests;
using FluentValidation;

namespace EmployeeManagementSystem.Application.Validators
{
    public class AuthValidator : AbstractValidator<LoginRequest>
    {
        public AuthValidator()
        {
            RuleFor(auth => auth.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(auth => auth.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        }
    }
}
