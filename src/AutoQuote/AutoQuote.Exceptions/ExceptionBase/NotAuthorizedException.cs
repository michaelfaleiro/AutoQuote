using System.Net;

namespace AutoQuote.Exceptions.ExceptionBase;

public class NotAuthorizedException(string message) : AutoQuoteExceptionBase(message)
{
    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.Unauthorized;
    }

    public override IList<string> GetErrorMessages()
    {
        return new List<string> { Message };
    }
}