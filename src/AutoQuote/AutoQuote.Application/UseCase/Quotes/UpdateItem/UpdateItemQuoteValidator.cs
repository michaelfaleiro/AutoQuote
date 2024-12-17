using AutoQuote.Communication.Request.Items;
using FluentValidation;

namespace AutoQuote.Application.UseCase.Quotes.UpdateItem;

public class UpdateItemQuoteValidator : AbstractValidator<UpdateItemQuoteRequest>
{
    public UpdateItemQuoteValidator()
    {
        RuleFor(x => x.QuoteId).NotEmpty();
        RuleFor(x => x.ItemId).NotEmpty();
        RuleFor(x => x.Item.Sku).NotEmpty();
        RuleFor(x => x.Item.Name).NotEmpty();
        RuleFor(x => x.Item.Quantity).GreaterThan(0);
    }
    
}