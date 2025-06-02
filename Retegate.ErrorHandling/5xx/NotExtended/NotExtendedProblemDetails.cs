using System.Net;

namespace Retegate.ErrorHandling._5xx.NotExtended;

public sealed class NotExtendedProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Not Extended";
    public HttpStatusCode StatusCode => HttpStatusCode.NotExtended;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}