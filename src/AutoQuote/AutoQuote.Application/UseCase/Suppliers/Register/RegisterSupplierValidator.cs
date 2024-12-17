using AutoQuote.Communication.Request.Suppliers;
using FluentValidation;

namespace AutoQuote.Application.UseCase.Suppliers.Register;

public class RegisterSupplierValidator : AbstractValidator<RegisterSupplierRequest>
{
    public RegisterSupplierValidator()
    {
        RuleFor(x => x.LegalName)
            .NotEmpty()
            .MaximumLength(100);
        
        RuleFor(x => x.TradeName)
            .NotEmpty()
            .MaximumLength(100);
        
        RuleFor(x => x.TaxId)
            .NotEmpty()
            .MaximumLength(20);
        
        RuleFor(x => x.Phone)
            .NotEmpty()
            .MaximumLength(20);
        
    }
    
}