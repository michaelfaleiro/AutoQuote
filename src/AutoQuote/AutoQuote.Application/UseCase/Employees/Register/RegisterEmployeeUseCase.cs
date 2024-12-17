using AutoQuote.Application.Validator;
using AutoQuote.Communication.Request.Employees;
using AutoQuote.Communication.Response;
using AutoQuote.Communication.Response.Employees;
using AutoQuote.Core.Entities;
using AutoQuote.Core.Repositories.Employees;

namespace AutoQuote.Application.UseCase.Employees.Register;

public class RegisterEmployeeUseCase : ValidateBase<RegisterEmployeeRequest>
{
    private readonly IEmployeeRepository _employeeRepository;
    
    public RegisterEmployeeUseCase(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    
    public async Task<ResponseJson<EmployeeResponseJson>> Execute(RegisterEmployeeRequest request)
    {
        Validate(request, new RegisterEmployeeValidator());
        
        var employee = new Employee(
            request.Name,
            request.Email,
            request.Password,
            request.Role);
        
        var response = await _employeeRepository.CreateAsync(employee);
        
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