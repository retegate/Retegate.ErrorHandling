using System.Net;
using System.Text.Json;

using FluentValidation;
using FluentValidation.Results;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Moq;

using Retegate.ErrorHandling._4xx.BadRequest;
using Retegate.ErrorHandling._4xx.Conflict;
using Retegate.ErrorHandling._4xx.NotFound;
using Retegate.ErrorHandling._5xx.InternalServiceError;

using Shouldly;

namespace Retegate.ErrorHandling.Tests;

public class ErrorHandlingMiddlewareTests
{
    private const string ExpectedMessage = "test";

    private readonly Mock<ILogger<ErrorHandlingMiddleware>> _loggerMock = new();

    [Fact]
    public async Task MiddlewareTest_WithConflictException_ReturnsConflictProblemDetails()
    {
        await MiddlewareTest_WithSpecificException_ReturnsRelatedProblemDetails<ConflictException<object>,
            ConflictProblemDetails<object>>(new ConflictException<object>(ExpectedMessage, new object()),
            HttpStatusCode.Conflict, ConflictProblemDetails<object>.DefaultTitle);
    }

    [Fact]
    public async Task MiddlewareTest_WithValidationException_ReturnsBadRequestProblemDetails()
    {
        const string testPropertyName = "property";
        const string testPropertyValue = "value";

        var problemDetails =
            await MiddlewareTest_WithSpecificException_ReturnsRelatedProblemDetails<ValidationException,
                BadRequestProblemDetails>(
                new ValidationException(ExpectedMessage, [new ValidationFailure(testPropertyName, testPropertyValue)]),
                HttpStatusCode.BadRequest, BadRequestProblemDetails.DefaultTitle);

        problemDetails.ValidationFailures.ShouldHaveSingleItem();
        problemDetails.ValidationFailures.First().PropertyName.ShouldBe(testPropertyName);
        problemDetails.ValidationFailures.First().ErrorMessage.ShouldBe(testPropertyValue);
    }

    [Fact]
    public async Task MiddlewareTest_WithNotFoundException_ReturnsNotFoundProblemDetails2()
    {
        await MiddlewareTest_WithSpecificException_ReturnsRelatedProblemDetails<NotFoundException<object>,
            NotFoundProblemDetails<object>>(new NotFoundException<object>(ExpectedMessage, new object()),
            HttpStatusCode.NotFound, NotFoundProblemDetails<object>.DefaultTitle);
    }

    private async Task<TProblemDetails>
        MiddlewareTest_WithSpecificException_ReturnsRelatedProblemDetails<TException, TProblemDetails>(TException ex,
            HttpStatusCode statusCode, string title) where TException : Exception
        where TProblemDetails : class, IProblemDetails
    {
        using var host = await new HostBuilder()
            .ConfigureWebHost(webBuilder =>
            {
                webBuilder
                    .UseTestServer()
                    .ConfigureServices(services =>
                    {
                        services.AddScoped<ILogger<ErrorHandlingMiddleware>>(_ => _loggerMock.Object);
                        services.AddScoped<ErrorHandlingMiddleware>();
                        services.AddScoped<HelperMiddleware<TException>>(_ => new HelperMiddleware<TException>(ex));
                    })
                    .Configure(app =>
                    {
                        app.UseMiddleware<ErrorHandlingMiddleware>();
                        app.UseMiddleware<HelperMiddleware<TException>>();
                    });
            })
            .StartAsync();

        var response = await host.GetTestClient().GetAsync("/");

        response.StatusCode.ShouldBe(statusCode);
        var json = await response.Content.ReadAsStringAsync();

        var problemDetails = JsonSerializer.Deserialize<TProblemDetails>(json);

        problemDetails.ShouldNotBeNull();
        problemDetails.Title.ShouldBe(title);
        problemDetails.Details.ShouldBe(ExpectedMessage);

        return problemDetails;
    }

    [Fact]
    public async Task MiddlewareTest_WithUnknownException_ReturnsInternalServerErrorProblemDetails()
    {
        using var host = await new HostBuilder()
            .ConfigureWebHost(webBuilder =>
            {
                webBuilder
                    .UseTestServer()
                    .ConfigureServices(services =>
                    {
                        services.AddScoped<ILogger<ErrorHandlingMiddleware>>(_ => _loggerMock.Object);
                        services.AddScoped<ErrorHandlingMiddleware>();
                        services.AddScoped<HelperMiddleware<Exception>>(_ =>
                            new HelperMiddleware<Exception>(new Exception(ExpectedMessage)));
                    })
                    .Configure(app =>
                    {
                        app.UseMiddleware<ErrorHandlingMiddleware>();
                        app.UseMiddleware<HelperMiddleware<Exception>>();
                    });
            })
            .StartAsync();

        var response = await host.GetTestClient().GetAsync("/");

        response.StatusCode.ShouldBe(HttpStatusCode.InternalServerError);
        var json = await response.Content.ReadAsStringAsync();

        var problemDetails = JsonSerializer.Deserialize<InternalServiceErrorProblemDetails>(json);

        problemDetails.ShouldNotBeNull();
    }
}