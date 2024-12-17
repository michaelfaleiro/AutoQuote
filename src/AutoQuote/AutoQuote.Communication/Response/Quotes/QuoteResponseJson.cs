using AutoQuote.Core.Enums;
using AutoQuote.Core.ValueObject;

namespace AutoQuote.Communication.Response.Quotes;

public record QuoteResponseJson(
    string Id,
    Vehicle Vehicle,
    EStatusQuote StatusQuote,
    string EmployeeName,
    DateTime CreatedAt,
    DateTime? UpdatedAt
    );