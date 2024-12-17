namespace AutoQuote.Core.Repositories;

public interface IDeleteRepository
{
    Task DeleteAsync(string id);
}