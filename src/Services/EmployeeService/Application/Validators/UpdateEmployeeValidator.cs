using FluentValidation;
using EmployeeManagementSystem.Application.CQRS.Commands;
using EmployeeManagementSystem.Application.CQRS.Handlers;

namespace EmployeeManagementSystem.Application.Validation
{
    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Employee ID is required.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid email format.");
        }
    }
}

