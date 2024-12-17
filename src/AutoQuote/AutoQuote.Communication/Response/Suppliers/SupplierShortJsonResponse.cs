using AutoQuote.Core.ValueObject;

namespace AutoQuote.Communication.Response.Suppliers;

public record SupplierShortJsonResponse(
    string Id,
    string LegalName,
    string TradeName,
    string TaxId,
    Address Address,
    string Phone,
    Email Email);