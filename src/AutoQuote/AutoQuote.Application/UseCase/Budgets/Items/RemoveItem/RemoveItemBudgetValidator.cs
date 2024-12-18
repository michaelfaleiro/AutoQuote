using AutoQuote.Communication.Request.Budgets;
using FluentValidation;

namespace AutoQuote.Application.UseCase.Budgets.Items.RemoveItem;

public class RemoveItemBudgetValidator : AbstractValidator<RemoveItemBudgetRequest>
{
    public RemoveItemBudgetValidator()
    {
        RuleFor(x => x.BudgetId)
            .NotEmpty()
            .WithMessage("BudgetId is required");

        RuleFor(x => x.ItemId)
            .NotEmpty()
            .WithMessage("ItemId is required");
    }
    
}