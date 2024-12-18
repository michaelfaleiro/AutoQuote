using AutoQuote.Application.Validator;
using AutoQuote.Communication.Request.Budgets;
using AutoQuote.Communication.Response;
using AutoQuote.Communication.Response.Budgets;
using AutoQuote.Communication.Response.ItemsBudget;
using AutoQuote.Core.Repositories.Budgets;
using AutoQuote.Exceptions.ExceptionBase;

namespace AutoQuote.Application.UseCase.Budgets.Items.RemoveItem;

public class RemoveItemBudgetUseCase : ValidateBase<RemoveItemBudgetRequest>
{
    private readonly IBudgetRepository _budgetRepository;
    
    public RemoveItemBudgetUseCase(IBudgetRepository budgetRepository)
    {
        _budgetRepository = budgetRepository;
    }
    
    public async Task<ResponseJson<BudgetResponseJson>> ExecuteAsync(RemoveItemBudgetRequest request)
    {
        Validate(request, new RemoveItemBudgetValidator());
        
        var budget = await _budgetRepository.GetByIdAsync(request.BudgetId) 
                     ?? throw new NotFoundException("Budget not found");
        
        var item = budget.Items.FirstOrDefault(x => x.Id == request.ItemId) 
                   ?? throw new NotFoundException("Item not found");
        
        budget.RemoveItem(item);
        
        await _budgetRepository.UpdateAsync(budget);
        
        return new ResponseJson<BudgetResponseJson>(
            new BudgetResponseJson(
                budget.Id, 
                budget.EmployeeName,
                budget.Vehicle, 
                budget.Items.Select(x => new ItemsBudgetResponseJson(
                    x.Id, x.Sku, x.Name, x.Quantity, x.Price, x.CreatedAt, x.UpdatedAt)),
                budget.StatusBudget,
                budget.CreatedAt,
                budget.UpdatedAt));
        
    }
    
}