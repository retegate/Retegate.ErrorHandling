using System.Net;

namespace Retegate.ErrorHandling._4xx.ProxyAuthenticationRequired;

public sealed class ProxyAuthenticationRequiredProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Proxy Authentication Required";
    public HttpStatusCode StatusCode => HttpStatusCode.ProxyAuthenticationRequired;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}