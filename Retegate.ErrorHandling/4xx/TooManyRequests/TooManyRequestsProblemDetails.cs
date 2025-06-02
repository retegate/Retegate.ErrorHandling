using System.Net;

namespace Retegate.ErrorHandling._4xx.TooManyRequests;

public sealed class TooManyRequestsProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Too Many Requests";
    public HttpStatusCode StatusCode => HttpStatusCode.TooManyRequests;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}