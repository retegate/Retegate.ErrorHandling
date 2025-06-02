using System.Net;

namespace Retegate.ErrorHandling._4xx.NotFound;

public sealed class NotFoundProblemDetails<TData>(
    string details,
    string logTraceId,
    TData missingDataDescriptor)
    : IProblemDetails
{
    internal const string DefaultTitle = "Not Found";

    public string Type => Constants.Rfc;
    public string Title => DefaultTitle;
    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    public string Details { get; } = details;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
    public TData MissingDataDescriptor { get; } = missingDataDescriptor;
}