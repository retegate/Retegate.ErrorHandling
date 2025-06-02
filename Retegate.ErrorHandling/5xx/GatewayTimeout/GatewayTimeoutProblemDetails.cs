using System.Net;

namespace Retegate.ErrorHandling._5xx.GatewayTimeout;

public sealed class GatewayTimeoutProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Gateway Timeout";
    public HttpStatusCode StatusCode => HttpStatusCode.GatewayTimeout;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}