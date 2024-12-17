using AutoQuote.Communication.Response.Token;

namespace AutoQuote.Application.Services.Token;

public interface ITokenService
{
    (string Token, DateTime ExpiresIn) GenerateToken(string userId, string role);
    bool ValidateToken(string token);
    string GenerateRefreshToken(string userId);
    bool ValidateRefreshToken(string userId, string refreshToken);
}