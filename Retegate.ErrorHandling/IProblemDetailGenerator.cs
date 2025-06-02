namespace Retegate.ErrorHandling;

public interface IProblemDetailGenerator<TProblemDetails> where TProblemDetails : IProblemDetails
{
    TProblemDetails Generate(string logTraceId);
}