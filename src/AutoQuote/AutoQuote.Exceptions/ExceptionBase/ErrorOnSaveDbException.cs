using System.Net;

namespace AutoQuote.Exceptions.ExceptionBase;

public class ErrorOnSaveDbException(string message) : AutoQuoteExceptionBase(message)
{
    public override HttpStatusCode GetStatusCode() => HttpStatusCode.InternalServerError;
    
    public override IList<string> GetErrorMessages() => new List<string> { Message };
    
}