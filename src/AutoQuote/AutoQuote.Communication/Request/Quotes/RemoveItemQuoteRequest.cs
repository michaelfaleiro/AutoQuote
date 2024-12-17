namespace AutoQuote.Communication.Request.Quotes;

public record RemoveItemQuoteRequest(
    string QuoteId,
    string ItemId
);
