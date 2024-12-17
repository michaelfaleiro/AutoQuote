using AutoQuote.Exceptions.ExceptionBase;

namespace AutoQuote.Core.Entities;

public class RefreshToken : Entity
{
    public string UserId { get; private set; }
    public string Role { get; private set; }
    public string Token { get; private set; }
    public DateTime Expiration { get; private set; }
    public bool IsRevoked { get; private set; } 
    public DateTime? RevokedAt { get; private set; }
    public bool IsActive => !IsRevoked && DateTime.UtcNow <= Expiration;
    

    public RefreshToken(string userId, string role, string token, DateTime expiration)
    {
        UserId = userId;
        Role = role;
        Token = token;
        Expiration = expiration;
        IsRevoked = false;
    }

    public void Revoke()
    {
        IsRevoked = true;
        RevokedAt = DateTime.UtcNow;
    }
    
    public void UpdateToken(string token, DateTime expiration)
    {
        if (IsRevoked)
            throw new BussinesException("Cannot update a revoked token");
        Token = token;
        Expiration = expiration;
        UpdatedAt = DateTime.UtcNow;
    }
    
}