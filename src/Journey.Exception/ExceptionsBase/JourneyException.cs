using System.Net;

namespace Journey.Exception.ExceptionsBase;

public abstract class JourneyException : SystemException
{
    public JourneyException(string msg) : base(msg)
    {

    }

    public abstract HttpStatusCode GetStatusCode();
    public abstract IList<string> GetErrorMessages();
}

