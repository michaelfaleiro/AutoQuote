using AutoQuote.Core.ValueObject;

namespace AutoQuote.Communication.Request.Budgets;

public record UpdateBudgetRequest(
    string BudgetId,
    string EmployeeName,
    Vehicle Vehicle
    );