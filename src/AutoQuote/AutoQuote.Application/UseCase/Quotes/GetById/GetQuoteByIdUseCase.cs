using AutoQuote.Communication.Response;
using AutoQuote.Communication.Response.Quotes;
using AutoQuote.Core.Repositories.Quotes;
using AutoQuote.Exceptions.ExceptionBase;

namespace AutoQuote.Application.UseCase.Quotes.GetById;

public class GetQuoteByIdUseCase
{
    private readonly IQuoteRepository _quoteRepository;
    
    public GetQuoteByIdUseCase(IQuoteRepository quoteRepository)
    {
        _quoteRepository = quoteRepository;
    }
    
    public async Task<ResponseJson<QuoteResponseJson>> ExecuteAsync(string id)
    {
        var response = await _quoteRepository.GetByIdAsync(id) 
                       ?? throw new NotFoundException("Quote not found");

        return new ResponseJson<QuoteResponseJson>(
            new QuoteResponseJson(
                response.Id, response.Vehicle, response.StatusQuote,
                response.EmployeeName, response.CreatedAt, response.UpdatedAt));
    }
}