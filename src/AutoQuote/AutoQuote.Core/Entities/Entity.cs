namespace AutoQuote.Core.Entities;

public abstract class Entity
{
    protected Entity()
    {
        Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        CreatedAt = DateTime.UtcNow;
    }
    
    public string Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; set; }
}