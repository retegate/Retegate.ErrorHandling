using System.Net;

namespace Retegate.ErrorHandling._4xx.RangeNotSatisfiable;

public sealed class RangeNotSatisfiableProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Range Not Satisfiable";
    public HttpStatusCode StatusCode => HttpStatusCode.RequestedRangeNotSatisfiable;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}