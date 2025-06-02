namespace Retegate.ErrorHandling._4xx.NotFound;

public sealed class NotFoundException<TData>(string message, TData missingData)
    : ExceptionBase<NotFoundProblemDetails<TData>>(message)
{
    public override NotFoundProblemDetails<TData> Generate(string logTraceId)
    {
        return new NotFoundProblemDetails<TData>(Message, logTraceId, missingData);
    }
}