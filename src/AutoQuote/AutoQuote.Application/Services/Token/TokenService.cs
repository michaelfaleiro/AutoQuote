using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoQuote.Communication.Response.Token;
using Microsoft.IdentityModel.Tokens;

namespace AutoQuote.Application.Services.Token;

public class TokenService : ITokenService
{
    private readonly string _secretKey;
    private readonly Dictionary<string, string> _refreshTokens = new();

    public TokenService(string secretKey)
    {
        _secretKey = secretKey;
    }

    public (string Token, DateTime ExpiresIn) GenerateToken(string userId, string role)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secretKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, userId),
                new Claim(ClaimTypes.Role, role)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            )
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return (tokenHandler.WriteToken(token), tokenDescriptor.Expires.Value);
    }

    public string GenerateRefreshToken(string userId)
    {
        var refreshToken = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        _refreshTokens[userId] = refreshToken;
        return refreshToken;
    }

    public bool ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secretKey);

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            }, out _);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool ValidateRefreshToken(string userId, string refreshToken)
    {
        return _refreshTokens.TryGetValue(userId, out var storedRefreshToken) && storedRefreshToken == refreshToken;
    }
}