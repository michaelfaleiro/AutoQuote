using AutoQuote.Communication.Request.ItemsBudget;
using FluentValidation;

namespace AutoQuote.Application.UseCase.Budgets.Items.UpdateItem;

public class UpdateItemBudgetValidator : AbstractValidator<UpdateItemBudgetRequest>
{
    public UpdateItemBudgetValidator()
    {
        RuleFor(x => x.BudgetId)
            .NotEmpty()
            .WithMessage("BudgetId is required");
        
        RuleFor(x => x.ItemId)
            .NotEmpty()
            .WithMessage("ItemId is required");
        
        RuleFor(x => x.Sku)
            .NotEmpty()
            .WithMessage("Sku is required");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required");

        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than 0");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0");
    }
    
}