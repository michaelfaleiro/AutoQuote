using AutoQuote.Core.Enums;
using AutoQuote.Core.ValueObject;

namespace AutoQuote.Core.Entities;

public class Quote : Entity
{
    public Quote(Vehicle vehicle, EStatusQuote statusQuote, Employee employee)
    {

        Vehicle = vehicle;
        StatusQuote = statusQuote;
        EmployeeName = employee.Name;
        Items = new List<Item>();
    }

    public Vehicle Vehicle { get; private set; }
    public IList<Item> Items { get; private set; }
    public EStatusQuote StatusQuote { get; private set; }
    public string EmployeeName { get; private set; }

    public void AddItem(Item item)
    {
        Items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        Items.Remove(item);
    }
}