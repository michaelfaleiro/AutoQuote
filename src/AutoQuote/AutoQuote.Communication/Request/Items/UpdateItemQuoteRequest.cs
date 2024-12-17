namespace AutoQuote.Communication.Request.Items;

public record UpdateItemQuoteRequest(
    string QuoteId,
    string ItemId,
    RegisterItemRequest Item
    );