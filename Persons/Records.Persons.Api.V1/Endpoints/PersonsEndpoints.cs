#region Usings

using Records.Shared.Http.Entities;

#endregion

namespace Records.Persons.Api.V1.Endpoints;

public static class PersonsEndpoints
{
    public static IEndpointRouteBuilder MapPersonasEndpoints(this IEndpointRouteBuilder app)
    {
        // Crea un grupo de rutas para organizar los endpoints relacionados con un path comun y nombre de grupo.
        RouteGroupBuilder routeGroup = app.MapGroup("/persons").WithTags("Persons");

        // GET persons/test/{id}/data.
        routeGroup.MapGet("/test/{id}/data", GetTestData)
            .WithName("GetTest/newData")
            .Produces<ErrorResponse>(StatusCodes.Status400BadRequest);

        // GET persons/exception1.
        routeGroup.MapGet("/test/exception1", GetException1)
            .WithName("GetException1")
            .Produces<ErrorResponse>(StatusCodes.Status400BadRequest);

        return app;
    }

    /// <summary>GET test1/{id}/data.</summary>
    /// <remarks>Endpoint de prueba para verificar conectividad.</remarks>
    /// <param name="id" example="Abc123">ID único del elemento a recuperar.</param>
    /// <response code="200">Éxito: Elemento encontrado.</response>
    /// <response code="400">Request inválido. Devuelve MyError.</response>
    private static string GetTestData(
        string id,
        HttpContext httpContext,
        ILogger<Program> logger)
    {
        logger.LogWarning("Warning de prueba en GetTestData() para id {Id}", id);
        return "Test 2 API ok";
    }

    private static IResult GetException1(HttpContext context)
    {
        #pragma warning disable CA2201
        Exception ex = new Exception("Excepción de prueba 1");
        #pragma warning restore CA2201
        ex.Data.Add("Id", context.TraceIdentifier);
        throw ex;
    }
}
