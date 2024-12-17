namespace AutoQuote.Communication.Response.Prices;

public record PriceSupplierJson(
    string Id,
    string QuoteId,
    string SupllierName,
    decimal Price,
    DateTime CreatedAt,
    DateTime UpdatedAt
    );