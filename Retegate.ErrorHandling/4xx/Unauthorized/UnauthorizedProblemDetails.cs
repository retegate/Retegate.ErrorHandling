using System.Net;

namespace Retegate.ErrorHandling._4xx.Unauthorized;

public sealed class UnauthorizedProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Unauthorized";
    public HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}