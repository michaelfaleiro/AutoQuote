using AutoQuote.Communication.Response.ItemsBudget;
using AutoQuote.Core.Enums;
using AutoQuote.Core.ValueObject;

namespace AutoQuote.Communication.Response.Budgets;

public record BudgetResponseJson(
    string Id,
    string EmployeeName,
    Vehicle Vehicle,
    IEnumerable<ItemsBudgetResponseJson> Items,
    EStatusBudget Status,
    DateTime CreatedAt,
    DateTime? UpdatedAt
    );