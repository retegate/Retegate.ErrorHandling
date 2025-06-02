using System.Net;

namespace Retegate.ErrorHandling._4xx.ExpectationFailed;

public sealed class ExpectationFailedProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Expectation Failed";
    public HttpStatusCode StatusCode => HttpStatusCode.ExpectationFailed;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}