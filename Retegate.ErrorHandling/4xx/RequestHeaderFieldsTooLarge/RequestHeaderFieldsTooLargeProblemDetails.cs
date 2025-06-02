using System.Net;

namespace Retegate.ErrorHandling._4xx.RequestHeaderFieldsTooLarge;

public sealed class RequestHeaderFieldsTooLargeProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Request Header Fields Too Large";
    public HttpStatusCode StatusCode => HttpStatusCode.RequestHeaderFieldsTooLarge;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}