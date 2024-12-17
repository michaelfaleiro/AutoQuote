using AutoQuote.Core.Entities;
using AutoQuote.Core.Repositories.Employees;
using AutoQuote.Core.Response;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AutoQuote.Infra.Data.Repositories.Employees;

public class EmployeeRepository : MongoBaseRepository.MongoRepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(IOptions<MongoDbSettings> mongoDbSettings)
        : base(mongoDbSettings, "Employees")
    {
    }

    public async Task<Employee?> GetByIdAsync(string id)
    {
        return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<PagedResponse<Employee>> GetAllAsync(int page, int pageSize)
    {
        var total = await _collection.CountDocumentsAsync(_ => true);

        var data = await _collection.Find(_ => true)
            .Skip((page - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync();

        return new PagedResponse<Employee>(data, page, pageSize, (int)total);
    }

    public async Task<Employee> CreateAsync(Employee entity)
    {
        await _collection.InsertOneAsync(entity);
        return entity;
    }

    public async Task UpdateAsync(Employee entity)
    {
        await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<Employee?> GetByEmailAsync(string email)
    {
        return await _collection.Find(x => x.Email == email).FirstOrDefaultAsync();
    }
}