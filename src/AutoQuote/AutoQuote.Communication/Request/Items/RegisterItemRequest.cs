namespace AutoQuote.Communication.Request.Items;

public record RegisterItemRequest(
    string Sku,
    string Name,
    int Quantity
);
