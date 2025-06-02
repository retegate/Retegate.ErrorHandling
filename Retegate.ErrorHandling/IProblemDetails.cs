using System.Net;

namespace Retegate.ErrorHandling;

public interface IProblemDetails
{
    string Type { get; }
    string Title { get; }
    HttpStatusCode StatusCode { get; }
    int Status => (int)StatusCode;
    string Details { get; }
    string Instance { get; }
    string LogTraceId { get; }
}