namespace AutoQuote.Communication.Request.Login;

public record LoginRequest(
    string Email,
    string Password
);