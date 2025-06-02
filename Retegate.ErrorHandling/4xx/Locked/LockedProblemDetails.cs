using System.Net;

namespace Retegate.ErrorHandling._4xx.Locked;

public sealed class LockedProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Locked";
    public HttpStatusCode StatusCode => HttpStatusCode.Locked;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}