using System.Net;

namespace AutoQuote.Exceptions.ExceptionBase;

public class ErrorOnValidateException(IList<string> messages) : AutoQuoteExceptionBase(string.Empty)
{
    public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
    
    public override IList<string> GetErrorMessages()
    {
        return messages;
    }
    
}