using AutoQuote.Core.Entities;

namespace AutoQuote.Core.Repositories.Employees;

public interface IEmployeeRepository : IBaseRepository<Employee>, IDeleteRepository
{
    Task<Employee?> GetByEmailAsync(string email);
}