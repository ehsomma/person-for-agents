using Microsoft.AspNetCore.Http;
using System.Net;
using Records.Shared.Entities;

namespace Records.Shared.Http;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
    {
        // TODO: Asignar código http de acuerdo al tipo de excepción.
        // Ver: https://github.com/ehsomma/ddd-cqrs-microservices/blob/master/Src/Services/Shared/Records.Shared.Infra.Http/Middlewares/GlobalExceptionHandlerMiddleware.cs
        MyError myError = new MyError()
        {
            Code = 123,
            Description = ex.Message,
        };

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        await httpContext.Response.WriteAsJsonAsync(myError);
    }
}
