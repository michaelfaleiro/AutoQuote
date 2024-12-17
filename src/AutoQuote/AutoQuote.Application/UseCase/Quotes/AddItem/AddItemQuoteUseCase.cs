using AutoQuote.Application.Validator;
using AutoQuote.Communication.Request.Quotes;
using AutoQuote.Core.Entities;
using AutoQuote.Core.Repositories.Quotes;
using AutoQuote.Exceptions.ExceptionBase;

namespace AutoQuote.Application.UseCase.Quotes.AddItem;

public class AddItemQuoteUseCase : ValidateBase<AddItemQuoteRequest>
{
    private readonly IQuoteRepository _quoteRepository;
    
    public AddItemQuoteUseCase(IQuoteRepository quoteRepository)
    {
        _quoteRepository = quoteRepository;
    }
    
    public async Task ExecuteAsync(AddItemQuoteRequest request)
    {
        Validate(request, new AddItemQuoteValidator());
        
        var quote = await _quoteRepository.GetByIdAsync(request.QuoteId) 
                    ?? throw new NotFoundException("Quote not found");
        
        var item = new Item(request.Item.Sku, request.Item.Name, request.Item.Quantity);
        
        quote.AddItem(item);
        
        await _quoteRepository.UpdateAsync(quote);
    }
}