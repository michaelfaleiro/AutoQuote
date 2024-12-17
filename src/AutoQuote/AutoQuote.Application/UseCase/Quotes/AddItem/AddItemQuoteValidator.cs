using AutoQuote.Communication.Request.Quotes;
using FluentValidation;

namespace AutoQuote.Application.UseCase.Quotes.AddItem;

public class AddItemQuoteValidator : AbstractValidator<AddItemQuoteRequest>
{
    public AddItemQuoteValidator()
    {
        RuleFor(x => x.QuoteId).NotEmpty();
        RuleFor(x => x.Item.Sku).NotEmpty();
        RuleFor(x => x.Item.Name).NotEmpty();
        RuleFor(x => x.Item.Quantity).GreaterThan(0);
    }
}
