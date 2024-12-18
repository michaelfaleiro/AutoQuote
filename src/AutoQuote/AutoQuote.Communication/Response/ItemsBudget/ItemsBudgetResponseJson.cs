namespace AutoQuote.Communication.Response.ItemsBudget;

public record ItemsBudgetResponseJson(
    string Id,
    string Sku,
    string Name,
    int Quantity,
    decimal Price,
    DateTime CreatedAt,
    DateTime? UpdatedAt);