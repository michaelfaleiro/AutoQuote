using AutoQuote.Communication.Response;
using AutoQuote.Communication.Response.Quotes;
using AutoQuote.Core.Repositories.Quotes;

namespace AutoQuote.Application.UseCase.Quotes.GetAll;

public class GetAllQuotesUseCase
{
    private readonly IQuoteRepository _quoteRepository;

    public GetAllQuotesUseCase(IQuoteRepository quoteRepository)
    {
        _quoteRepository = quoteRepository;
    }

    public async Task<PagedResponse<QuoteResponseJson>> ExecuteAsync(int page, int pageSize)
    {
        var response = await _quoteRepository.GetAllAsync(page, pageSize);

        var data = response.Data.Select(x =>
            new QuoteResponseJson(x.Id, x.Vehicle, x.StatusQuote, x.EmployeeName, x.CreatedAt, x.UpdatedAt));

        return new PagedResponse<QuoteResponseJson>(data, response.Page, response.PageSize, response.Total);
    }
}