using AutoQuote.Core.Entities;
using AutoQuote.Core.Repositories.RefreshTokens;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AutoQuote.Infra.Data.Repositories.RefreshTokens;

public class RefreshTokenRepository : MongoBaseRepository.MongoRepositoryBase<RefreshToken>, IRefreshTokenRepository
{
    public RefreshTokenRepository(IOptions<MongoDbSettings> mongoDbSettings)
        : base(mongoDbSettings, "RefreshTokens")
    {
    }

    public async Task<RefreshToken> GetByTokenAsync(string refreshToken)
    {
        return await _collection.Find(x => x.Token == refreshToken).FirstOrDefaultAsync();
    }

    public async Task AddAsync(RefreshToken refreshToken)
    {
        await _collection.InsertOneAsync(refreshToken);
    }

    public async Task UpdateAsync(RefreshToken refreshToken)
    {
        await _collection.ReplaceOneAsync(x => x.Id == refreshToken.Id, refreshToken);
    }
}