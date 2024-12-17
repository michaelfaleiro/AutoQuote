namespace AutoQuote.Communication.Response.Items;

public record ItemShortResponseJson(
    string Id,
    string Sku,
    string Name,
    int Quantity,
    DateTime CreatedAt,
    DateTime UpdatedAt
    );