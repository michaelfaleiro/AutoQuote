using AutoQuote.Communication.Request.Quotes;
using FluentValidation;

namespace AutoQuote.Application.UseCase.Quotes.RemoveItem;

public class RemoveItemQuoteValidator : AbstractValidator<RemoveItemQuoteRequest>
{
    public RemoveItemQuoteValidator()
    {
        RuleFor(x => x.QuoteId).NotEmpty();
        RuleFor(x => x.ItemId).NotEmpty();
    }
    
}