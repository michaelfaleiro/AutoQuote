using AutoQuote.Application.UseCase.Authentication;
using AutoQuote.Application.UseCase.Employees.GetAll;
using AutoQuote.Application.UseCase.Employees.GetById;
using AutoQuote.Application.UseCase.Employees.Register;
using Microsoft.Extensions.DependencyInjection;

namespace AutoQuote.Application.Services;

public static class EmployeeService
{
    public static IServiceCollection AddEmployeeService(this IServiceCollection services)
    {
        services.AddScoped<RegisterEmployeeUseCase>();
        services.AddScoped<GetEmployeeByIdUseCase>();
        services.AddScoped<GetAllEmployeesUseCase>();
       
        return services;
    }
}