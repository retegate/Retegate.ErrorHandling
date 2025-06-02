using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Retegate.ErrorHandling;

public static class ServiceRegistration
{
    public static IServiceCollection AddErrorHandlingServices(this IServiceCollection services)
    {
        services.AddScoped<ErrorHandlingMiddleware>();
        return services;
    }

    public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
    {
        app.UseMiddleware<ErrorHandlingMiddleware>();
        return app;
    }
}