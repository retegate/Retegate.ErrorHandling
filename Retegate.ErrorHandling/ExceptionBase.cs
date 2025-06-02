namespace Retegate.ErrorHandling;

public abstract class ExceptionBase<TProblemDetails>(
    string message,
    Exception? innerException = null)
    : Exception(message, innerException), IProblemDetailGenerator<TProblemDetails>
    where TProblemDetails : IProblemDetails
{
    public abstract TProblemDetails Generate(string logTraceId);
}