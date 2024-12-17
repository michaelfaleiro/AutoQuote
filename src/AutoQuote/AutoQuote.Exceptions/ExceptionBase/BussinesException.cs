using System.Net;

namespace AutoQuote.Exceptions.ExceptionBase;

public class BussinesException(string message) : AutoQuoteExceptionBase(message)
{
    public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
    
    public override IList<string> GetErrorMessages() => new List<string> { Message };
}