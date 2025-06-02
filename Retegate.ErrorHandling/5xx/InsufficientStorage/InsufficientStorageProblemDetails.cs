using System.Net;

namespace Retegate.ErrorHandling._5xx.InsufficientStorage;

public sealed class InsufficientStorageProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Insufficient Storage";
    public HttpStatusCode StatusCode => HttpStatusCode.InsufficientStorage;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}