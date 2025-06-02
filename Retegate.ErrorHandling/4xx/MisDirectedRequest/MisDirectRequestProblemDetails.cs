using System.Net;

namespace Retegate.ErrorHandling._4xx.MisDirectedRequest;

public sealed class MisDirectRequestProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Misdirected Request";
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.MisdirectedRequest;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}