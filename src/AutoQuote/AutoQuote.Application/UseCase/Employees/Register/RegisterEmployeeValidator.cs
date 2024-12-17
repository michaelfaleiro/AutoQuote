using AutoQuote.Communication.Request.Employees;
using FluentValidation;

namespace AutoQuote.Application.UseCase.Employees.Register;

public class RegisterEmployeeValidator : AbstractValidator<RegisterEmployeeRequest>
{
    public RegisterEmployeeValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Email is invalid");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .MinimumLength(6)
            .WithMessage("Password must be at least 6 characters");

        RuleFor(x => x.Role)
            .NotEmpty()
            .WithMessage("Role is required");
    }
    
}