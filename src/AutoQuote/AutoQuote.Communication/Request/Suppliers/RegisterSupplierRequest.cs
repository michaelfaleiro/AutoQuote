using AutoQuote.Core.ValueObject;

namespace AutoQuote.Communication.Request.Suppliers;

public record RegisterSupplierRequest(
    string LegalName,
    string TradeName,
    string TaxId,
    string StateRegistration,
    string MunicipalRegistration,
    Address Address,
    string Phone,
    Email Email,
    string Website,
    string Notes
    );