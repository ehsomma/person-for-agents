using Microsoft.AspNetCore.Http;
using System.Net;
using Records.Shared.Entities;

namespace Records.Shared.Http;

public class GlobalExceptionHandlerMiddleware
{
    public GlobalExceptionHandlerMiddleware()
    {
        ////_next = next;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(next);

        try
        {
            await next(context);
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
