using EmployeeManagementSystem.Application.DTOs.Requests;
using FluentValidation;

namespace EmployeeManagementSystem.Application.Validators
{
    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeRequest>
    {
        public UpdateEmployeeValidator()
        {
            RuleFor(e => e.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(e => e.LastName).NotEmpty().WithMessage("Last name is required.");
            RuleFor(e => e.PhoneNumbers).NotEmpty().WithMessage("At least one phone number is required.");
        }
    }
}
