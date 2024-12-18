using AutoQuote.Communication.Request.Budgets;
using FluentValidation;

namespace AutoQuote.Application.UseCase.Budgets.Items.AddItem;

public class AddItemBudgetValidator : AbstractValidator<AddItemBudgetRequest>
{
    public AddItemBudgetValidator()
    {
        RuleFor(x => x.BudgetId)
            .NotEmpty()
            .WithMessage("BudgetId is required");
        
        RuleFor(x => x.Item.Sku)
            .NotEmpty()
            .WithMessage("Sku is required");

        RuleFor(x => x.Item.Name)
            .NotEmpty()
            .WithMessage("Name is required");

        RuleFor(x => x.Item.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than 0");

        RuleFor(x => x.Item.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0");
    }
}