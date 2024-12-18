using AutoQuote.Application.Validator;
using AutoQuote.Communication.Request.Budgets;
using AutoQuote.Communication.Response;
using AutoQuote.Communication.Response.Budgets;
using AutoQuote.Communication.Response.ItemsBudget;
using AutoQuote.Core.Entities;
using AutoQuote.Core.Repositories.Budgets;
using AutoQuote.Core.ValueObject;

namespace AutoQuote.Application.UseCase.Budgets.Register;

public class RegisterBudgetUseCase : ValidateBase<RegisterBudgetRequest>
{
    private readonly IBudgetRepository _budgetRepository;
    
    public RegisterBudgetUseCase(IBudgetRepository budgetRepository)
    {
        _budgetRepository = budgetRepository;
    }
    
    public async Task<ResponseJson<BudgetResponseJson>> ExecuteAsync(RegisterBudgetRequest request)
    {
        Validate(request, new RegisterBudgetValidator());
        
        var vehicle = new Vehicle(
            request.Vehicle.Plate, request.Vehicle.Chassis, request.Vehicle.Renavam, request.Vehicle.Model,
            request.Vehicle.Manufacturer, request.Vehicle.Year, request.Vehicle.Color, request.Vehicle.Engine);
        
        var budget = new Budget(request.EmpolyeeName, vehicle, request.StatusBudget );
        
        var result = await _budgetRepository.CreateAsync(budget);
        
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