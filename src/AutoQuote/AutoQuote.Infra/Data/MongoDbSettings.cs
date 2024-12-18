namespace AutoQuote.Infra.Data;

public class MongoDbSettings
{
    public string ConnectionUri { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public Dictionary<string, string> Collections { get; set; } = [];
}