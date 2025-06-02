using System.Net;

namespace Retegate.ErrorHandling._4xx.PreconditionFailed;

public sealed class PreconditionFailedProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Precondition Failed";
    public HttpStatusCode StatusCode => HttpStatusCode.PreconditionFailed;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}