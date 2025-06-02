using System.Net;

namespace Retegate.ErrorHandling._5xx.HttpVersionNotSupported;

public sealed class HttpVersionNotSupportedProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Http Version Not Supported";
    public HttpStatusCode StatusCode => HttpStatusCode.HttpVersionNotSupported;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}