using System.Net;

namespace Retegate.ErrorHandling._4xx.NotAcceptable;

public sealed class NotAcceptableProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Not Acceptable";
    public HttpStatusCode StatusCode => HttpStatusCode.NotAcceptable;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}