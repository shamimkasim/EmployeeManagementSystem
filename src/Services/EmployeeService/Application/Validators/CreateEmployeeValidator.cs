using FluentValidation;
using EmployeeManagementSystem.Application.CQRS.Commands;

namespace EmployeeManagementSystem.Application.Validation
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.DateOfBirth).NotEmpty().LessThan(DateTime.UtcNow.AddYears(-18))
                .WithMessage("Employee must be at least 18 years old.");
        }
    }
}

