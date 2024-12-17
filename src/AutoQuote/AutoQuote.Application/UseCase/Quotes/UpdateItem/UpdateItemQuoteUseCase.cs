using AutoQuote.Application.Validator;
using AutoQuote.Communication.Request.Items;
using AutoQuote.Core.Entities;
using AutoQuote.Core.Repositories.Quotes;
using AutoQuote.Exceptions.ExceptionBase;

namespace AutoQuote.Application.UseCase.Quotes.UpdateItem;

public class UpdateItemQuoteUseCase : ValidateBase<UpdateItemQuoteRequest>
{
    private readonly IQuoteRepository _quoteRepository;
    
    public UpdateItemQuoteUseCase(IQuoteRepository quoteRepository)
    {
        _quoteRepository = quoteRepository;
    }
    
    public async Task ExecuteAsync(UpdateItemQuoteRequest request)
    {
        Validate(request, new UpdateItemQuoteValidator());
        
        var quote = await _quoteRepository.GetByIdAsync(request.QuoteId) 
                    ?? throw new NotFoundException("Quote not found");
        
        var item = quote.Items.FirstOrDefault(x => x.Id == request.ItemId) 
                   ?? throw new NotFoundException("Item not found");
        
        var itemUpdate = new Item(request.Item.Sku, request.Item.Name, request.Item.Quantity);
        
        item.Update(itemUpdate);
        
        await _quoteRepository.UpdateAsync(quote);
    }
}