using AutoQuote.Communication.Response.Prices;
using AutoQuote.Core.Enums;
using AutoQuote.Core.ValueObject;

namespace AutoQuote.Communication.Response.Quotes;

public record QuoteFullResponseJson(
    string Id,
    Vehicle Vehicle,
    EStatusQuote StatusQuote,
    IEnumerable<PriceSupplierJson> Prices,
    string EmployeeName,
    DateTime CreatedAt,
    DateTime? UpdatedAt
    );