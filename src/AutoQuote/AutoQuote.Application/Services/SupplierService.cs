using AutoQuote.Application.UseCase.Suppliers.Delete;
using AutoQuote.Application.UseCase.Suppliers.GetAll;
using AutoQuote.Application.UseCase.Suppliers.GetById;
using AutoQuote.Application.UseCase.Suppliers.Register;
using AutoQuote.Application.UseCase.Suppliers.Update;
using Microsoft.Extensions.DependencyInjection;

namespace AutoQuote.Application.Services;

public static class SupplierService
{
    public static IServiceCollection AddSupplierService(this IServiceCollection services)
    {
        services.AddScoped<RegisterSupplierUseCase>();
        services.AddScoped<GetAllSuppliersUseCase>();
        services.AddScoped<GetByIdUseCase>();
        services.AddScoped<DeleteSupplierUseCase>();
        services.AddScoped<UpdateSupplierUseCase>();
        
        return services;
    }
    
}