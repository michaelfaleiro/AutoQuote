using AutoQuote.Core.Response;

namespace AutoQuote.Core.Repositories;

public interface IBaseRepository<T> where T : class
{
    Task<T?> GetByIdAsync(string id);
    Task<PagedResponse<T>> GetAllAsync(int page, int pageSize);
    Task<T> CreateAsync(T entity);
    Task UpdateAsync(T entity);
}