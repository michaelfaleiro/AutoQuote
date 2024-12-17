using AutoQuote.Application.Validator;
using AutoQuote.Communication.Request.Quotes;
using AutoQuote.Communication.Response;
using AutoQuote.Communication.Response.Quotes;
using AutoQuote.Core.Entities;
using AutoQuote.Core.Repositories.Employees;
using AutoQuote.Core.Repositories.Quotes;

namespace AutoQuote.Application.UseCase.Quotes.Register;

public class RegisterQuoteUseCase : ValidateBase<RegisterQuoteRequest>
{
    private readonly IQuoteRepository _quoteRepository;
    private readonly IEmployeeRepository _employeeRepository;
    
    public RegisterQuoteUseCase(IQuoteRepository quoteRepository, IEmployeeRepository employeeRepository)
    {
        _quoteRepository = quoteRepository;
        _employeeRepository = employeeRepository;
    }
    
    public async Task<ResponseJson<QuoteResponseJson>> Execute(RegisterQuoteRequest request)
    {
        Validate(request, new RegisterQuoteValidator());
        
        var employee = await _employeeRepository.GetByIdAsync(request.EmployeeId)
                       ?? throw new Exception("Employee not found");
        
        var quote = new Quote(request.Vehicle, request.StatusQuote, employee);
        
        var response = await _quoteRepository.CreateAsync(quote);
        
        return new ResponseJson<QuoteResponseJson>(
            new QuoteResponseJson(
                response.Id, response.Vehicle, response.StatusQuote,
                response.EmployeeName, response.CreatedAt, response.UpdatedAt));
    }
    
}
    