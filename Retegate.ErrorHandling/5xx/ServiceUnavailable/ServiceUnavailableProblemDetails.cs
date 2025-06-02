using System.Net;

namespace Retegate.ErrorHandling._5xx.ServiceUnavailable;

public sealed class ServiceUnavailableProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Service Unavailable";
    public HttpStatusCode StatusCode => HttpStatusCode.ServiceUnavailable;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}