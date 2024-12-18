namespace AutoQuote.Communication.Request.ItemsBudget;

public record UpdateItemBudgetRequest(
    string BudgetId,
    string ItemId,
    string Sku,
    string Name,
    int Quantity,
    decimal Price
    );
