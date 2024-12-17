using AutoQuote.Core.ValueObject;

namespace AutoQuote.Core.Entities;

public class Supplier : Entity
{
    public Supplier(string legalName, string tradeName, string taxId, string stateRegistration,
        string municipalRegistration, Address address, string phone, Email email,
         string website, string notes)
    {
        LegalName = legalName;
        TradeName = tradeName;
        TaxId = taxId;
        StateRegistration = stateRegistration;
        MunicipalRegistration = municipalRegistration;
        Address = address;
        Phone = phone;
        Email = email;
        Contacts = new List<Contact>();
        Website = website;
        Notes = notes;
        Activate();
    }
    
    
    public string LegalName { get; private set; }
    public string TradeName { get; private set; }
    public string TaxId { get; private set; }
    public string StateRegistration { get;  private set; }
    public string MunicipalRegistration { get; private set; }
    public Address Address { get; private set; }
    public string Phone { get; private set; }
    public Email Email { get; private set; }
    public IList<Contact> Contacts { get;  private set; }
    public string Website { get; private set; }
    public string Notes { get; private set; }
    public bool Active { get; private set; }
    
    public void Update(string legalName, string tradeName, string taxId, string stateRegistration,
        string municipalRegistration, Address address, string phone, Email email,
         string website, string notes)
    {
        LegalName = legalName;
        TradeName = tradeName;
        TaxId = taxId;
        StateRegistration = stateRegistration;
        MunicipalRegistration = municipalRegistration;
        Address = address;
        Phone = phone;
        Email = email;
        Website = website;
        Notes = notes;
        UpdatedAt = DateTime.UtcNow;
    }
    
    
    public void AddContact(Contact contact)
    {
        Contacts.Add(contact);
    }
    
    public void RemoveContact(Contact contact)
    {
        Contacts.Remove(contact);
    }
    
    public void UpdateContact(Contact contact)
    {
        var existingContact = Contacts.FirstOrDefault(c => c.Name == contact.Name);
        if (existingContact == null) return;
        
        existingContact.Name = contact.Name;
        existingContact.Email = contact.Email;
        existingContact.Phone = contact.Phone;
        existingContact.CellPhone = contact.CellPhone;
    }
    
    public void Activate()
    {
        Active = true;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void Deactivate()
    {
        Active = false;
        UpdatedAt = DateTime.UtcNow;
    }
    
}