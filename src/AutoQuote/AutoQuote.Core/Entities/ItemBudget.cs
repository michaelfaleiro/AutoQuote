namespace AutoQuote.Core.Entities;

public class ItemBudget : Entity
{

    public ItemBudget(string sku, string name, int quantity, decimal price)
    {
        Sku = sku;
        Name = name;
        Quantity = quantity;
        Price = price;
    }
    
    public string Sku { get; private set; }
    public string Name { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
    
    public void Update(ItemBudget item)
    {
        Sku = item.Sku;
        Name = item.Name;
        Quantity = item.Quantity;
        Price = item.Price;
        UpdatedAt = DateTime.UtcNow;
    }
}