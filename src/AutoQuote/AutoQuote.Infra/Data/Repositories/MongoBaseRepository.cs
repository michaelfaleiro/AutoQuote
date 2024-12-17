using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AutoQuote.Infra.Data.Repositories;

public abstract class MongoBaseRepository
{
    public abstract class MongoRepositoryBase<T>
    {
        protected readonly IMongoCollection<T> _collection;

        protected MongoRepositoryBase(IOptions<MongoDbSettings> mongoDbSettings, string collectionName)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionUri);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _collection = database.GetCollection<T>(collectionName);
        }
    }
}