using System.Net;

namespace Retegate.ErrorHandling._5xx.VariantAlsoNegotiates;

public sealed class VariantAlsoNegotiatesProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Variant Also Negotiates";
    public HttpStatusCode StatusCode => HttpStatusCode.VariantAlsoNegotiates;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}