using AutoQuote.Core.Entities;
using AutoQuote.Core.Repositories.Suppliers;
using AutoQuote.Core.Response;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using static AutoQuote.Infra.Data.Repositories.MongoBaseRepository;

namespace AutoQuote.Infra.Data.Repositories.Suppliers;

public class SupplierRepository : MongoRepositoryBase<Supplier>, ISupplierRepository
{
    public SupplierRepository(IOptions<MongoDbSettings> mongoDbSettings) : base(mongoDbSettings, "Suppliers")
    {
    }
    
    public async Task<Supplier> CreateAsync(Supplier entity)
    {
        return await _collection.InsertOneAsync(entity).ContinueWith(_ => entity);
    }

    public async Task UpdateAsync(Supplier entity)
    {
        await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<PagedResponse<Supplier>> GetAllAsync(int page, int pageSize)
    {
        var total = await _collection.CountDocumentsAsync(_ => true);

        var data = await _collection.Find(_ => true)
            .Skip((page - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync();

        return new PagedResponse<Supplier>(data, page, pageSize, (int)total);
    }

    public async Task<Supplier?> GetByIdAsync(string id)
    {
        return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }
}