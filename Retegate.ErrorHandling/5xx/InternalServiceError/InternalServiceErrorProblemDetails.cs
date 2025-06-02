using System.Net;

namespace Retegate.ErrorHandling._5xx.InternalServiceError;

public sealed class InternalServiceErrorProblemDetails(string details, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Internal Server Error";
    public HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;
    public string Details { get; } = details;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}