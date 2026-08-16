#region Usings

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Records.Shared.Entities;

#endregion

namespace Records.Shared.Http;

public sealed class GlobalExceptionHandler(
    ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(httpContext);
        ArgumentNullException.ThrowIfNull(exception);

        // TODO: Asignar código http de acuerdo al tipo de excepción.
        // Ver: https://github.com/ehsomma/ddd-cqrs-microservices/blob/master/Src/Services/Shared/Records.Shared.Infra.Http/Middlewares/GlobalExceptionHandlerMiddleware.cs
        MyError myError = new MyError()
        {
            Code = 123,
            Description = exception.Message,
        };

        // TODO: Implementar el should log segun el tipo de excepción (por ahora loguea todo).
        bool shouldLog = true;
        if (shouldLog)
        {
            logger.LogError(exception, "Excepción no controlada en {Path}", httpContext.Request.Path);
        }

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        await httpContext.Response.WriteAsJsonAsync(myError, cancellationToken);

        return true; // manejada, cortá acá.
    }
}
