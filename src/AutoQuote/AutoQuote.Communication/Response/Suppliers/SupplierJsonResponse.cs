using AutoQuote.Core.ValueObject;

namespace AutoQuote.Communication.Response.Suppliers;

public record SupplierJsonResponse(
    string Id,
    string LegalName,
    string TradeName,
    string TaxId,
    string StateRegistration,
    string MunicipalRegistration,
    Address Address,
    string Phone,
    Email Email,
    string Website,
    string Notes);