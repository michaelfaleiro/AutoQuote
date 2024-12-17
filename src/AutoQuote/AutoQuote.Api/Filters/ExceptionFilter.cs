using AutoQuote.Communication.Response;
using AutoQuote.Exceptions.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AutoQuote.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is AutoQuoteExceptionBase autoQuoteException)
        {
            context.HttpContext.Response.StatusCode = (int)autoQuoteException.GetStatusCode();
            context.Result = new ObjectResult(CreateResponseErrorJson(autoQuoteException.GetErrorMessages()));
        }
        else
        {
            Console.WriteLine(context.Exception);
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(CreateResponseErrorJson(new List<string> { "Erro interno no servidor" }));
        }
    }

    private ResponseErrorJson CreateResponseErrorJson(IList<string> errorMessages)
    {
        return new ResponseErrorJson(errorMessages.ToList());
    }
}