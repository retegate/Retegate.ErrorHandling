using System.Net;

using FluentValidation.Results;

namespace Retegate.ErrorHandling._4xx.BadRequest;

public sealed class BadRequestProblemDetails(
    string details,
    IEnumerable<ValidationFailure> validationFailures,
    string logTraceId)
    : IProblemDetails
{
    internal const string DefaultTitle = "Bad Request";

    public string Type => Constants.Rfc;
    public string Title => DefaultTitle;
    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    public string Details { get; } = details;
    public string Instance { get; } = Helper.InstanceMessage(logTraceId);
    public string LogTraceId { get; } = logTraceId;
    public IEnumerable<ValidationFailure> ValidationFailures { get; } = validationFailures;
}