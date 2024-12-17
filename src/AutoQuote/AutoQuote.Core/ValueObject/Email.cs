namespace AutoQuote.Core.ValueObject;

public class Email : ValueObject
{
    public Email(string address)
    {
        Address = address;
    }

    public string Address { get; set; }
}