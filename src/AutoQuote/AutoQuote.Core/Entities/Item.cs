namespace AutoQuote.Core.Entities;

public class Item : Entity
{
   public Item(string sku, string name, int quantity)
    {
        Sku = sku;
        Name = name;
        Quantity = quantity;
        PricesSupplier = new List<PriceSupplier>();
        Similars = new List<string>();
    }


    public string Sku { get; private set; }
    public string Name { get; private set; }
    public int Quantity { get; private set; }
    public IList<PriceSupplier> PricesSupplier { get; private set; }
    public IList<string> Similars { get; private set; }
    
    public void Update(Item item)
    {
        Sku = item.Sku;
        Name = item.Name;
        Quantity = item.Quantity;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void AddPriceSupplier(PriceSupplier priceSupplier)
    {
        PricesSupplier.Add(priceSupplier);
    }
    
    public void RemovePriceSupplier(PriceSupplier priceSupplier)
    {
        PricesSupplier.Remove(priceSupplier);
    }
    
    public void UpdatePriceSupplier(PriceSupplier priceSupplier)
    {
        var existingPriceSupplier = PricesSupplier.FirstOrDefault(p => p.SupplierId == priceSupplier.SupplierId);

        existingPriceSupplier?.Update(priceSupplier);
    }
    
    public void AddSimilar(string sku)
    {
        Similars.Add(sku);
    }
    
    public void RemoveSimilar(string sku)
    {
        Similars.Remove(sku);
    }
    
    public void UpdateSimilar(string sku)
    {
        var existingSimilar = Similars.FirstOrDefault(s => s == sku);
        if (existingSimilar == null) return;
        
        existingSimilar = sku;
    }
    
}