using AutoQuote.Core.Repositories.Suppliers;
using AutoQuote.Exceptions.ExceptionBase;

namespace AutoQuote.Application.UseCase.Suppliers.Delete;

public class DeleteSupplierUseCase
{
    private readonly ISupplierRepository _supplierRepository;
    
    public DeleteSupplierUseCase(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }
    
    public async Task ExecuteAsync(string id)
    {
        var supplier = await _supplierRepository.GetByIdAsync(id) 
                       ?? throw new NotFoundException("Supplier not found");
        
        await _supplierRepository.DeleteAsync(supplier.Id);
    }
        
}