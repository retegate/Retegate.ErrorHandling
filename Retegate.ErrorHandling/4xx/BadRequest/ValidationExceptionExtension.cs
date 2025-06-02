using FluentValidation;

namespace Retegate.ErrorHandling._4xx.BadRequest;

public static class ValidationExceptionExtension
{
    public static BadRequestProblemDetails CreateProblemDetails(this ValidationException exception, string logTraceId)
    {
        return new BadRequestProblemDetails(exception.Message, exception.Errors, logTraceId);
    }
}