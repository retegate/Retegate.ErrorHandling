using System.Net;

namespace Retegate.ErrorHandling._4xx.UnavailableForLegalReasons;

public sealed class UnavailableForLegalReasonsProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Unavailable For Legal Reasons";
    public HttpStatusCode StatusCode => HttpStatusCode.UnavailableForLegalReasons;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}