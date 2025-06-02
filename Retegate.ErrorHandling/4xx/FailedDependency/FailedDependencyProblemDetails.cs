using System.Net;

namespace Retegate.ErrorHandling._4xx.FailedDependency;

public sealed class FailedDependencyProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Failed Dependency";
    public HttpStatusCode StatusCode => HttpStatusCode.FailedDependency;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}