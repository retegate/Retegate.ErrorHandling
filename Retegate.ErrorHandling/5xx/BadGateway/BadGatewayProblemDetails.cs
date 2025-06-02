using System.Net;

namespace Retegate.ErrorHandling._5xx.BadGateway;

public sealed class BadGatewayProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Bad Gateway";
    public HttpStatusCode StatusCode => HttpStatusCode.BadGateway;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}