namespace AutoQuote.Communication.Response.Items;

public record ItemReponseJson(
    string Id,
    string Sku,
    string Name,
    int Quantity,
    DateTime CreatedAt,
    DateTime UpdatedAt
    );