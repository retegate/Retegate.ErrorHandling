using Microsoft.AspNetCore.Http;

namespace Retegate.ErrorHandling.Tests;

public class HelperMiddleware<TEx>(TEx ex) : IMiddleware where TEx : Exception
{
    public Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        throw ex;
    }
}