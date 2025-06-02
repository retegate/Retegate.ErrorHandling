using System.Net;

namespace Retegate.ErrorHandling._4xx.PreconditionRequired;

public sealed class PreconditionRequiredProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Precondition Required";
    public HttpStatusCode StatusCode => HttpStatusCode.PreconditionRequired;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}