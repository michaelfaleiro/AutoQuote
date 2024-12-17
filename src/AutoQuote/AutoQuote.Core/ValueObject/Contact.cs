namespace AutoQuote.Core.ValueObject;

public class Contact : ValueObject
{
    public Contact(string name, string email, string phone, string cellPhone)
    {
        Name = name;
        Email = email;
        Phone = phone;
        CellPhone = cellPhone;
    }
    
    
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string CellPhone { get; set; }
}