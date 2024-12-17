using AutoQuote.Communication.Request.Items;

namespace AutoQuote.Communication.Request.Quotes;

public record AddItemQuoteRequest(
    string QuoteId,
    RegisterItemRequest Item
);