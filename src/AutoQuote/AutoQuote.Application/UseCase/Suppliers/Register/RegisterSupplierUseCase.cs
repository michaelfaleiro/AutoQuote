using AutoQuote.Application.UseCase.Quotes.Register;
using AutoQuote.Application.Validator;
using AutoQuote.Communication.Request.Quotes;
using AutoQuote.Communication.Request.Suppliers;
using AutoQuote.Communication.Response;
using AutoQuote.Communication.Response.Suppliers;
using AutoQuote.Core.Entities;
using AutoQuote.Core.Repositories.Suppliers;

namespace AutoQuote.Application.UseCase.Suppliers.Register;

public class RegisterSupplierUseCase : ValidateBase<RegisterSupplierRequest>
{
    private readonly ISupplierRepository _supplierRepository;
    
    
    public RegisterSupplierUseCase(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }
    
    public async Task<ResponseJson<SupplierJsonResponse>> ExecuteAsync(RegisterSupplierRequest request)
    {
        Validate(request, new RegisterSupplierValidator());
        
        var supplier = new Supplier(
            request.LegalName,
            request.TradeName,
            request.TaxId,
            request.StateRegistration,
            request.MunicipalRegistration,
            request.Address,
            request.Phone,
            request.Email,
            request.Website,
            request.Notes);
        
        await _supplierRepository.CreateAsync(supplier);
        
        return new ResponseJson<SupplierJsonResponse>(
            new SupplierJsonResponse(
                supplier.Id,
                supplier.LegalName,
                supplier.TradeName,
                supplier.TaxId,
                supplier.StateRegistration,
                supplier.MunicipalRegistration,
                supplier.Address,
                supplier.Phone,
                supplier.Email,
                supplier.Website,
                supplier.Notes));
        
    }
}