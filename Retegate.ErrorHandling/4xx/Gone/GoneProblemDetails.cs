using System.Net;

namespace Retegate.ErrorHandling._4xx.Gone;

public sealed class GoneProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Gone";
    public HttpStatusCode StatusCode => HttpStatusCode.Gone;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}