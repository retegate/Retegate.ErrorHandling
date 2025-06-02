using System.Diagnostics;
using System.Text.Json;

using FluentValidation;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using Retegate.ErrorHandling._4xx.BadRequest;
using Retegate.ErrorHandling._4xx.Conflict;
using Retegate.ErrorHandling._4xx.NotFound;
using Retegate.ErrorHandling._5xx.InternalServiceError;

namespace Retegate.ErrorHandling;

public sealed class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
{
    private const string DefaultContentType = "application/problem+json";

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var logTraceId = context.TraceIdentifier;
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var activity = Activity.Current;
            if (activity != null)
            {
                activity.AddTag("exception.type", ex.GetType().ToString());
                activity.AddTag("exception.message", ex.Message);
                activity.AddTag("exception.stacktrace", ex.StackTrace ?? "");
                activity.SetStatus(ActivityStatusCode.Error);
            }

            logger.LogError("An error occurred during request processing: {Ex}", ex);
            var exceptionType = ex.GetType();

            if (exceptionType.IsGenericType && exceptionType.GetGenericTypeDefinition() == typeof(NotFoundException<>))
            {
                var genericArgument = exceptionType.GetGenericArguments()[0];
                var notFoundException = Convert.ChangeType(ex, typeof(NotFoundException<>).MakeGenericType(genericArgument));
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                context.Response.ContentType = DefaultContentType;

                var generateMethod = notFoundException.GetType().GetMethod("Generate");
                var notFoundProblemDetails = generateMethod!.Invoke(notFoundException, [logTraceId]);

                var json = JsonSerializer.Serialize(notFoundProblemDetails);
                await context.Response.WriteAsync(json);
            }
            else if (exceptionType.IsGenericType &&
                     exceptionType.GetGenericTypeDefinition() == typeof(ConflictException<>))
            {
                var genericArgument = exceptionType.GetGenericArguments()[0];
                var conflictException = Convert.ChangeType(ex, typeof(ConflictException<>).MakeGenericType(genericArgument));
                context.Response.StatusCode = StatusCodes.Status409Conflict;
                context.Response.ContentType = DefaultContentType;

                var generateMethod = conflictException.GetType().GetMethod("Generate");
                var conflictProblemDetails = generateMethod!.Invoke(conflictException, [logTraceId]);

                var json = JsonSerializer.Serialize(conflictProblemDetails);
                await context.Response.WriteAsync(json);
            }
            else if (exceptionType == typeof(ValidationException))
            {
                var validationException = ex as ValidationException;
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = DefaultContentType;
                var badRequestProblemDetails = validationException!.CreateProblemDetails(logTraceId);
                var json = JsonSerializer.Serialize(badRequestProblemDetails);
                await context.Response.WriteAsync(json);
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = DefaultContentType;
                var internalServerErrorProblemDetails = new InternalServiceErrorProblemDetails(ex.Message, logTraceId);
                var json = JsonSerializer.Serialize(internalServerErrorProblemDetails);
                await context.Response.WriteAsync(json);
            }
        }
    }
}