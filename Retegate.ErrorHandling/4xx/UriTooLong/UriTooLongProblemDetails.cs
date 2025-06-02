using System.Net;

namespace Retegate.ErrorHandling._4xx.UriTooLong;

public sealed class UriTooLongProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "URI Too Long";
    public HttpStatusCode StatusCode => HttpStatusCode.RequestUriTooLong;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}