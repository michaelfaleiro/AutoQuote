using AutoQuote.Exceptions.ExceptionBase;
using FluentValidation;

namespace AutoQuote.Application.Validator;

public abstract class ValidateBase<TRequest>
{
    protected void Validate(TRequest request, IValidator<TRequest> validator)
    {
        var result = validator.Validate(request);

        if (result.IsValid) return;

        throw new ErrorOnValidateException(result.Errors.Select(x => x.ErrorMessage).ToList());
    }
    
}