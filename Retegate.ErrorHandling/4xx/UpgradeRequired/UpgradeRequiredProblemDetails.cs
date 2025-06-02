using System.Net;

namespace Retegate.ErrorHandling._4xx.UpgradeRequired;

public sealed class UpgradeRequiredProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Upgrade Required";
    public HttpStatusCode StatusCode => HttpStatusCode.UpgradeRequired;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}