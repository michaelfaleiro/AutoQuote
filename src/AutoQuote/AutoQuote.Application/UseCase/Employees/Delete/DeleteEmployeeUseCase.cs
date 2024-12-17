using AutoQuote.Core.Repositories.Employees;
using AutoQuote.Exceptions.ExceptionBase;

namespace AutoQuote.Application.UseCase.Employees.Delete;

public class DeleteEmployeeUseCase
{
    private readonly IEmployeeRepository _employeeRepository;
    
    public DeleteEmployeeUseCase(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    
    public async Task ExecuteAsync(string id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id)
                       ?? throw new NotFoundException("Employee not found");
        
        await _employeeRepository.DeleteAsync(employee.Id);
    }
}