using AutoQuote.Communication.Request.ItemsBudget;

namespace AutoQuote.Communication.Request.Budgets;

public record AddItemBudgetRequest(
    string BudgetId,
    RegisterItemBudgetRequest Item
    );