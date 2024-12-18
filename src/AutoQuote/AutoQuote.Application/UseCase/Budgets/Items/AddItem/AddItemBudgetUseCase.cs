using AutoQuote.Application.Validator;
using AutoQuote.Communication.Request.Budgets;
using AutoQuote.Communication.Response;
using AutoQuote.Communication.Response.Budgets;
using AutoQuote.Communication.Response.ItemsBudget;
using AutoQuote.Core.Entities;
using AutoQuote.Core.Repositories.Budgets;
using AutoQuote.Exceptions.ExceptionBase;

namespace AutoQuote.Application.UseCase.Budgets.Items.AddItem;

public class AddItemBudgetUseCase : ValidateBase<AddItemBudgetRequest>
{
    private readonly IBudgetRepository _budgetRepository;
    
    public AddItemBudgetUseCase(IBudgetRepository budgetRepository)
    {
        _budgetRepository = budgetRepository;
    }
    
    public async Task<ResponseJson<BudgetResponseJson>> ExecuteAsync(AddItemBudgetRequest request)
    {
        Validate(request, new AddItemBudgetValidator());
        
        var budget = await _budgetRepository.GetByIdAsync(request.BudgetId) 
                     ?? throw new NotFoundException("Budget not found");
        
        var item = new ItemBudget(
            request.Item.Sku, request.Item.Name, request.Item.Quantity, request.Item.Price);
        
        budget.AddItem(item);
        
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