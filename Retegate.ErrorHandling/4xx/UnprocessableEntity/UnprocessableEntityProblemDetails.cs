using System.Net;

namespace Retegate.ErrorHandling._4xx.UnprocessableEntity;

public sealed class UnprocessableEntityProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Unprocessable Entity";
    public HttpStatusCode StatusCode => HttpStatusCode.UnprocessableEntity;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}