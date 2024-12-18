using AutoQuote.Communication.Response;
using AutoQuote.Communication.Response.Budgets;
using AutoQuote.Communication.Response.ItemsBudget;
using AutoQuote.Core.Repositories.Budgets;
using AutoQuote.Exceptions.ExceptionBase;

namespace AutoQuote.Application.UseCase.Budgets.GetById;

public class GetBudgetByIdUseCase
{
    private readonly IBudgetRepository _budgetRepository;
    
    public GetBudgetByIdUseCase(IBudgetRepository budgetRepository)
    {
        _budgetRepository = budgetRepository;
    }
    
    public async Task<ResponseJson<BudgetResponseJson>> ExecuteAsync(string id)
    {
        var result = await _budgetRepository.GetByIdAsync(id) 
                     ?? throw new NotFoundException("Budget not found");

        return new ResponseJson<BudgetResponseJson>(
            new BudgetResponseJson(
                result.Id, 
                result.EmployeeName,
                result.Vehicle, 
                result.Items.Select(x => new ItemsBudgetResponseJson(
                    x.Id, x.Sku, x.Name, x.Quantity, x.Price, x.CreatedAt, x.UpdatedAt)),
                result.StatusBudget,
                result.CreatedAt,
                result.UpdatedAt));
        
    }
}