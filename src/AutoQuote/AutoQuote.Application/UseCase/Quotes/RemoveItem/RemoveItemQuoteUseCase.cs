using AutoQuote.Application.Validator;
using AutoQuote.Communication.Request.Quotes;
using AutoQuote.Core.Repositories.Quotes;
using AutoQuote.Exceptions.ExceptionBase;

namespace AutoQuote.Application.UseCase.Quotes.RemoveItem;

public class RemoveItemQuoteUseCase : ValidateBase<RemoveItemQuoteRequest>
{
    private readonly IQuoteRepository _quoteRepository;
    
    public RemoveItemQuoteUseCase(IQuoteRepository quoteRepository)
    {
        _quoteRepository = quoteRepository;
    }
    
    public async Task ExecuteAsync(RemoveItemQuoteRequest request)
    {
        Validate(request, new RemoveItemQuoteValidator());
        
        var quote = await _quoteRepository.GetByIdAsync(request.QuoteId) 
                    ?? throw new NotFoundException("Quote not found");
        
        var item = quote.Items.FirstOrDefault(x => x.Id == request.ItemId) 
                   ?? throw new NotFoundException("Item not found");
        
        quote.RemoveItem(item);
        
        await _quoteRepository.UpdateAsync(quote);
    }
    
}