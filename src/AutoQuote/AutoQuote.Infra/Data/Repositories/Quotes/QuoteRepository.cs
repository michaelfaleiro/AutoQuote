using AutoQuote.Core.Entities;
using AutoQuote.Core.Repositories.Quotes;
using AutoQuote.Core.Response;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AutoQuote.Infra.Data.Repositories.Quotes;

public class QuoteRepository : MongoBaseRepository.MongoRepositoryBase<Quote>, IQuoteRepository
{
    public QuoteRepository(IOptions<MongoDbSettings> mongoDbSettings) : base(mongoDbSettings, "Quotes")
    {
    }


    public async Task<Quote?> GetByIdAsync(string id)
    {
        return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<PagedResponse<Quote>> GetAllAsync(int page, int pageSize)
    {
        var total = await _collection.CountDocumentsAsync(_ => true);

        var data = await _collection.Find(_ => true)
            .Skip((page - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync();

        return new PagedResponse<Quote>(data, page, pageSize, (int)total);
    }

    public async Task<Quote> CreateAsync(Quote entity)
    {
        return await _collection.InsertOneAsync(entity).ContinueWith(_ => entity);
    }

    public async Task UpdateAsync(Quote entity)
    {
        await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
    }
}
