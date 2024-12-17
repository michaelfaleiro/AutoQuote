namespace AutoQuote.Communication.Response.Token;

public record TokenResponseJson(
    string Token,
    string RefreshToken,
    DateTime ExpiresIn
);