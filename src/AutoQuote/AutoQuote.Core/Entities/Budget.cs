using AutoQuote.Core.Enums;
using AutoQuote.Core.ValueObject;

namespace AutoQuote.Core.Entities;

public class Budget : Entity
{
    public Budget(
        string employeeName, Vehicle vehicle, EStatusBudget statusBudget)
    {
        EmployeeName = employeeName;
        Vehicle = vehicle;
        StatusBudget = statusBudget;
        Items = new List<ItemBudget>();
        QuotesId = new List<string>();
    }
    public string EmployeeName { get; private set; }
    public Vehicle Vehicle { get; private set; }
    public IList<ItemBudget> Items { get; private set; }
    public IList<string> QuotesId { get; private set; }
    public EStatusBudget StatusBudget { get; private set; }
    
    
    public void UpdateBudget(string employeeName, Vehicle vehicle)
    {
        EmployeeName = employeeName;
        Vehicle = vehicle;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void AddItem(ItemBudget item)
    {
        Items.Add(item);
    }
    
    public void RemoveItem(ItemBudget item)
    {
        Items.Remove(item);
    }
    
    public void AddQuoteId(string quoteId)
    {
        QuotesId.Add(quoteId);
    }
    
    public void RemoveQuoteId(string quoteId)
    {
        QuotesId.Remove(quoteId);
    }
}
