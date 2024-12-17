using System.Net;

namespace AutoQuote.Exceptions.ExceptionBase;

public abstract class AutoQuoteExceptionBase(string message) : SystemException(message)
{
    public abstract HttpStatusCode GetStatusCode();
    public abstract IList<string> GetErrorMessages();
}