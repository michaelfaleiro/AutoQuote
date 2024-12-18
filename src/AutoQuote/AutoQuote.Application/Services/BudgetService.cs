using AutoQuote.Application.UseCase.Budgets.GetAll;
using AutoQuote.Application.UseCase.Budgets.GetById;
using AutoQuote.Application.UseCase.Budgets.Items.AddItem;
using AutoQuote.Application.UseCase.Budgets.Items.RemoveItem;
using AutoQuote.Application.UseCase.Budgets.Items.UpdateItem;
using AutoQuote.Application.UseCase.Budgets.Register;
using Microsoft.Extensions.DependencyInjection;

namespace AutoQuote.Application.Services;

public static class BudgetService
{
    public static IServiceCollection AddBudgetService(this IServiceCollection services)
    {
        services.AddScoped<RegisterBudgetUseCase>();
        services.AddScoped<GetAllBudgetsUseCase>();
        services.AddScoped<GetBudgetByIdUseCase>();
        services.AddScoped<AddItemBudgetUseCase>();
        services.AddScoped<RemoveItemBudgetUseCase>();
        services.AddScoped<UpdateItemBudgetUseCase>();
        
        
        return services;
    }
}