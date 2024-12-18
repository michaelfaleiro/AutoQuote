using AutoQuote.Core.Enums;
using AutoQuote.Core.ValueObject;

namespace AutoQuote.Communication.Response.Budgets;

public record BudgetShortResponseJson(
    string Id,
    string EmployeeName,
    Vehicle Vehicle,
    EStatusBudget Status,
    DateTime CreatedAt,
    DateTime? UpdatedAt);