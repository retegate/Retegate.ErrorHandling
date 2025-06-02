using System.Net;

namespace Retegate.ErrorHandling._4xx.MethodNotAllowed;

public sealed class MethodNotAllowedProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Method Not Allowed";
    public HttpStatusCode StatusCode => HttpStatusCode.MethodNotAllowed;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}