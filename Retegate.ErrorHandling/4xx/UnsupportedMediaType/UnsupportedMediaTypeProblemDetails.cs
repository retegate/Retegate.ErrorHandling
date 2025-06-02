using System.Net;

namespace Retegate.ErrorHandling._4xx.UnsupportedMediaType;

public sealed class UnsupportedMediaTypeProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Unsupported Media Type";
    public HttpStatusCode StatusCode => HttpStatusCode.UnsupportedMediaType;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}