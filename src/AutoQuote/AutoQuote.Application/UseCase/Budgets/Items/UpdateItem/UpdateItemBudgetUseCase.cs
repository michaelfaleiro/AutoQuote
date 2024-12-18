using AutoQuote.Application.Validator;
using AutoQuote.Communication.Request.ItemsBudget;
using AutoQuote.Communication.Response;
using AutoQuote.Communication.Response.Budgets;
using AutoQuote.Communication.Response.ItemsBudget;
using AutoQuote.Core.Entities;
using AutoQuote.Core.Repositories.Budgets;
using AutoQuote.Exceptions.ExceptionBase;

namespace AutoQuote.Application.UseCase.Budgets.Items.UpdateItem;

public class UpdateItemBudgetUseCase : ValidateBase<UpdateItemBudgetRequest>
{
    private readonly IBudgetRepository _budgetRepository;
    
    public UpdateItemBudgetUseCase(IBudgetRepository budgetRepository)
    {
        _budgetRepository = budgetRepository;
    }
    
    public async Task<ResponseJson<BudgetResponseJson>> ExecuteAsync(UpdateItemBudgetRequest request)
    {
        Validate(request, new UpdateItemBudgetValidator());
        
        var budget = await _budgetRepository.GetByIdAsync(request.BudgetId) 
                     ?? throw new NotFoundException("Budget not found");
        
        var item = budget.Items.FirstOrDefault(x => x.Id == request.ItemId) 
                   ?? throw new NotFoundException("Item not found");
        
        var itemUpdate = new ItemBudget(
            request.Sku, request.Name, request.Quantity, request.Price);
        
        item.Update(itemUpdate);
        
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