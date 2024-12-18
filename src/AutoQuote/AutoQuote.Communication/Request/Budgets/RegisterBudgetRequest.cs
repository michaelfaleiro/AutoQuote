using AutoQuote.Core.Enums;
using AutoQuote.Core.ValueObject;

namespace AutoQuote.Communication.Request.Budgets;

public record RegisterBudgetRequest(
    string EmpolyeeName,
    Vehicle Vehicle,
    EStatusBudget StatusBudget
    );
