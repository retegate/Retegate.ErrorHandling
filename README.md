# .NET error handling class for web api

The pipeline behaviour is the solution to handle errors in a consistent way across the application.

As a inspiration the https://datatracker.ietf.org/doc/html/rfc9457 source was used.

Main motivation is to enable maximum predictable structure information into OpenAPI documentation for the REST API. The
Microsoft inbuild .NET ProblemDetails class is not sufficient in the details part which is a dictionary (i.e.
non-deterministic structure of data).

# License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.