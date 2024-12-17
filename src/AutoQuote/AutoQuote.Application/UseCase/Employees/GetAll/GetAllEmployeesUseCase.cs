using AutoQuote.Communication.Response;
using AutoQuote.Communication.Response.Employees;
using AutoQuote.Core.Repositories.Employees;

namespace AutoQuote.Application.UseCase.Employees.GetAll;

public class GetAllEmployeesUseCase
{
    private readonly IEmployeeRepository _employeeRepository;
    
    public GetAllEmployeesUseCase(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    
    public async Task<PagedResponse<EmployeeResponseJson>> ExecuteAsync(int page, int pageSize)
    {
        var response = await _employeeRepository.GetAllAsync(page, pageSize);

        var data = response.Data.Select(x => new EmployeeResponseJson(
            x.Id,
            x.Name,
            x.Email,
            x.Role,
            x.CreatedAt,
            x.UpdatedAt));
        
        return new PagedResponse<EmployeeResponseJson>(data, response.Page, response.PageSize, response.Total);
    }
}