namespace AutoQuote.Communication.Request.Budgets;

public record RemoveItemBudgetRequest(
    string BudgetId,
    string ItemId
    );
