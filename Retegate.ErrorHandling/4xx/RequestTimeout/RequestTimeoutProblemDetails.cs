using System.Net;

namespace Retegate.ErrorHandling._4xx.RequestTimeout;

public sealed class RequestTimeoutProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Request Timeout";
    public HttpStatusCode StatusCode => HttpStatusCode.RequestTimeout;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}