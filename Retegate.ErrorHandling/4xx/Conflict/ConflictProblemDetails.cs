using System.Net;

namespace Retegate.ErrorHandling._4xx.Conflict;

public sealed class ConflictProblemDetails<TData>(
    string details,
    string logTraceId,
    TData conflictingData)
    : IProblemDetails
{
    internal const string DefaultTitle = "Conflict";

    public string Type => Constants.Rfc;
    public string Title => DefaultTitle;
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string Details { get; } = details;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
    public TData ConflictingData { get; } = conflictingData;
}