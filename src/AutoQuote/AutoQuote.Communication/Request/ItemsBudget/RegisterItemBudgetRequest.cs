namespace AutoQuote.Communication.Request.ItemsBudget;

public record RegisterItemBudgetRequest(
    string Sku,
    string Name,
    int Quantity,
    decimal Price
    );