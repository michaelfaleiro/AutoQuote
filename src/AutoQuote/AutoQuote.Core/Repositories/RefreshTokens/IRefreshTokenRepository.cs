using AutoQuote.Core.Entities;

namespace AutoQuote.Core.Repositories.RefreshTokens;

public interface IRefreshTokenRepository
{
    Task<RefreshToken> GetByTokenAsync(string token);
    Task AddAsync(RefreshToken refreshToken);
    Task UpdateAsync(RefreshToken refreshToken);
}