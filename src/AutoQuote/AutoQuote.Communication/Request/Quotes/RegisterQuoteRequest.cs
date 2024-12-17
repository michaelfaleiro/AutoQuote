using AutoQuote.Core.Enums;
using AutoQuote.Core.ValueObject;

namespace AutoQuote.Communication.Request.Quotes;

public record RegisterQuoteRequest(
    string EmployeeId,
    Vehicle Vehicle,
    EStatusQuote StatusQuote
    );