using AutoQuote.Communication.Response;
using AutoQuote.Communication.Response.Employees;
using AutoQuote.Core.Repositories.Employees;
using AutoQuote.Exceptions.ExceptionBase;

namespace AutoQuote.Application.UseCase.Employees.GetById;

public class GetEmployeeByIdUseCase
{
    private readonly IEmployeeRepository _employeeRepository;
    
    public GetEmployeeByIdUseCase(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    
    public async Task<ResponseJson<EmployeeResponseJson>> ExecuteAsync(string id)
    {
        var response = await _employeeRepository.GetByIdAsync(id)
                       ?? throw new NotFoundException("Employee not found");

        return new ResponseJson<EmployeeResponseJson>(
            new EmployeeResponseJson(
                response.Id,
                response.Name,
                response.Email,
                response.Role,
                response.CreatedAt,
                response.UpdatedAt
            )
        );
    }
}