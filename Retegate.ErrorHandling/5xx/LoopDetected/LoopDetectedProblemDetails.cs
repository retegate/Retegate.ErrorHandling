using System.Net;

namespace Retegate.ErrorHandling._5xx.LoopDetected;

public sealed class LoopDetectedProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Loop Detected";
    public HttpStatusCode StatusCode => HttpStatusCode.LoopDetected;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}