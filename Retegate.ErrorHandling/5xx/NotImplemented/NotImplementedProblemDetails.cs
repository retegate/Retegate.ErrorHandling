using System.Net;

namespace Retegate.ErrorHandling._5xx.NotImplemented;

public sealed class NotImplementedProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Not Implemented";
    public HttpStatusCode StatusCode => HttpStatusCode.NotImplemented;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}