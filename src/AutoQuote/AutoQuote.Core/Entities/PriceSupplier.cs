namespace AutoQuote.Core.Entities;

public class PriceSupplier : Entity
{
    
    public PriceSupplier(string quoteId, string supplierId, string supplierName, decimal price)
    {
        QuoteId = quoteId;
        SupplierId = supplierId;
        SupplierName = supplierName;
        Price = price;
    }
    
    public string QuoteId { get; private set; }
    public string SupplierId { get; private set; }
    public string SupplierName { get; private set; }
    public decimal Price { get; private set; }
    
    
    public void Update(PriceSupplier priceSupplier)
    {
        SupplierId = priceSupplier.SupplierId;
        SupplierName = priceSupplier.SupplierName;
        Price = priceSupplier.Price;
        UpdatedAt = DateTime.UtcNow;
    }
    
    
}