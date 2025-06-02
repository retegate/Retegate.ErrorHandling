using System.Net;

namespace Retegate.ErrorHandling._4xx.PaymentRequired;

public sealed class PaymentRequiredProblemDetails(string message, string logTraceId) : IProblemDetails
{
    public string Type => Constants.Rfc;
    public string Title => "Payment Required";
    public HttpStatusCode StatusCode => HttpStatusCode.PaymentRequired;
    public string Details { get; } = message;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
}