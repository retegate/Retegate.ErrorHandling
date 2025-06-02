using System.Net;

namespace Retegate.ErrorHandling._4xx.LengthRequired;

public sealed class LengthRequiredProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Length Required";
    public HttpStatusCode StatusCode => HttpStatusCode.LengthRequired;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}