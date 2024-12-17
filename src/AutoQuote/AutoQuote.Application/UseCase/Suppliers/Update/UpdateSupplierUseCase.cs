using AutoQuote.Application.UseCase.Suppliers.Register;
using AutoQuote.Application.Validator;
using AutoQuote.Communication.Request.Suppliers;
using AutoQuote.Communication.Response;
using AutoQuote.Communication.Response.Suppliers;
using AutoQuote.Core.Repositories.Suppliers;
using AutoQuote.Exceptions.ExceptionBase;

namespace AutoQuote.Application.UseCase.Suppliers.Update;

public class UpdateSupplierUseCase : ValidateBase<RegisterSupplierRequest>
{
    private readonly ISupplierRepository _supplierRepository;
    
    public UpdateSupplierUseCase(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }
    
    public async Task<ResponseJson<SupplierJsonResponse>> ExecuteAsync(string supplierId,RegisterSupplierRequest request)
    {
        Validate(request, new RegisterSupplierValidator());
        
        var supplier = await _supplierRepository.GetByIdAsync(supplierId) 
                       ?? throw new NotFoundException("Supplier not found");
        
        supplier.Update(
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
        
        await _supplierRepository.UpdateAsync(supplier);
        
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