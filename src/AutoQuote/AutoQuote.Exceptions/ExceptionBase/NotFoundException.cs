using System.Net;

namespace AutoQuote.Exceptions.ExceptionBase;

public class NotFoundException(string message) : AutoQuoteExceptionBase(message)
{
    public override HttpStatusCode GetStatusCode() => HttpStatusCode.NotFound;
    
    public override IList<string> GetErrorMessages() => new List<string> { Message };
    
}