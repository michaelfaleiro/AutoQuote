using AutoQuote.Communication.Response;
using AutoQuote.Communication.Response.Suppliers;
using AutoQuote.Core.Repositories.Suppliers;

namespace AutoQuote.Application.UseCase.Suppliers.GetAll;

public class GetAllSuppliersUseCase
{
    private readonly ISupplierRepository _supplierRepository;
    
    public GetAllSuppliersUseCase(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task<PagedResponse<SupplierShortJsonResponse>> ExecuteAsync(int page, int pageSize)
    {
        var suppliers = await _supplierRepository.GetAllAsync(page, pageSize);

        return new PagedResponse<SupplierShortJsonResponse>
        {
            Data = suppliers.Data.Select(supplier => new SupplierShortJsonResponse(
                supplier.Id,
                supplier.LegalName,
                supplier.TradeName,
                supplier.TaxId,
                supplier.Address,
                supplier.Phone,
                supplier.Email
            )).ToList(),
            Page = suppliers.Page,
            PageSize = suppliers.PageSize,
            Total = suppliers.Total
        };
    }
}
    