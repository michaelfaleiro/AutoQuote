using AutoQuote.Communication.Request.Quotes;
using FluentValidation;

namespace AutoQuote.Application.UseCase.Quotes.Register;

public class RegisterQuoteValidator : AbstractValidator<RegisterQuoteRequest>
{
    public RegisterQuoteValidator()
    {
        RuleFor(x => x.Vehicle.Plate)
            .NotEmpty()
            .WithMessage("Informe a placa do veículo");

        RuleFor(x => x.Vehicle.Chassis)
            .NotEmpty()
            .WithMessage("Informe o chassi do veículo");

        RuleFor(x => x.Vehicle.Model)
            .NotEmpty()
            .WithMessage("Informe o modelo do veículo");
        
        RuleFor(x => x.Vehicle.Year)
            .GreaterThan(1900)
            .WithMessage("Informe um ano válido");
    }
}