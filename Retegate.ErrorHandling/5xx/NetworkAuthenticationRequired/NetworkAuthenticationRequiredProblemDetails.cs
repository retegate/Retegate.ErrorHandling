using System.Net;

namespace Retegate.ErrorHandling._5xx.NetworkAuthenticationRequired;

public sealed class NetworkAuthenticationRequiredProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Network Authentication Required";
    public HttpStatusCode StatusCode => HttpStatusCode.NetworkAuthenticationRequired;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}