using AutoQuote.Communication.Request.Budgets;
using FluentValidation;

namespace AutoQuote.Application.UseCase.Budgets.Register;

public class RegisterBudgetValidator : AbstractValidator<RegisterBudgetRequest>
{
    public RegisterBudgetValidator()
    {
        RuleFor(x => x.EmpolyeeName)
            .NotEmpty()
            .WithMessage("Employee name is required");
        
        RuleFor(x => x.Vehicle.Model)
            .NotEmpty()
            .WithMessage("Model is required");
        
        RuleFor(x => x.StatusBudget)
            .NotEmpty()
            .WithMessage("Status Budget is required");
    }
    
}