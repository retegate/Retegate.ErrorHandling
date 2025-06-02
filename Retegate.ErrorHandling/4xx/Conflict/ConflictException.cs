namespace Retegate.ErrorHandling._4xx.Conflict;

public sealed class ConflictException<TData>(string message, TData conflictingData)
    : ExceptionBase<ConflictProblemDetails<TData>>(message)
{
    public override ConflictProblemDetails<TData> Generate(string logTraceId)
    {
        return new ConflictProblemDetails<TData>(Message, logTraceId, conflictingData);
    }
}