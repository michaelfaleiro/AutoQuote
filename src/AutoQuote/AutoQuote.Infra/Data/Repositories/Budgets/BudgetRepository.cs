using AutoQuote.Core.Entities;
using AutoQuote.Core.Repositories.Budgets;
using AutoQuote.Core.Response;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AutoQuote.Infra.Data.Repositories.Budgets;

public class BudgetRepository : MongoBaseRepository.MongoRepositoryBase<Budget>, IBudgetRepository
{
    public BudgetRepository(IOptions<MongoDbSettings> mongoDbSettings) 
        : base(mongoDbSettings, "Budgets")
    {
    }

    public async Task<Budget?> GetByIdAsync(string id)
    {
        return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<PagedResponse<Budget>> GetAllAsync(int page, int pageSize)
    {
        var total = await _collection.CountDocumentsAsync(_ => true);

        var data = await _collection.Find(_ => true)
            .Skip((page - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync();

        return new PagedResponse<Budget>(data, page, pageSize, (int)total);
    }

    public async Task<Budget> CreateAsync(Budget entity)
    {
        await _collection.InsertOneAsync(entity);
        return entity;
    }

    public async Task UpdateAsync(Budget entity)
    {
        await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
    }
}