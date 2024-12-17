using AutoQuote.Communication.Response;
using AutoQuote.Communication.Response.Suppliers;
using AutoQuote.Core.Repositories.Suppliers;
using AutoQuote.Exceptions.ExceptionBase;

namespace AutoQuote.Application.UseCase.Suppliers.GetById;

public class GetByIdUseCase
{
    private readonly ISupplierRepository _supplierRepository;
    
    public GetByIdUseCase(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }
    
    public async Task<ResponseJson<SupplierJsonResponse>> ExecuteAsync(string id)
    { 
        var supplier = await _supplierRepository.GetByIdAsync(id) 
                       ?? throw new NotFoundException("Supplier not found");
        
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