using System.Net;

namespace Retegate.ErrorHandling._4xx.Forbidden;

public sealed class ForbiddenProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Forbidden";
    public HttpStatusCode StatusCode => HttpStatusCode.Forbidden;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}