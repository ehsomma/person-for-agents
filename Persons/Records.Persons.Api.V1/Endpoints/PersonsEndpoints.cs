using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi;
using Records.Persons.Api.V1.Entities;

namespace Records.Persons.Api.V1.Endpoints;

using Records.Shared.Entities;

public static class PersonsEndpoints
{
    public static IEndpointRouteBuilder MapPersonasEndpoints(this IEndpointRouteBuilder app)
    {
        // Crea un grupo de rutas para organizar los endpoints relacionados con un path comun y nombre de grupo.
        RouteGroupBuilder routeGroup = app.MapGroup("/tests").WithTags("Tests");

        // GET /test2/{id}/data.
        // **** Sin lambda, toma la documentación de XML! Con Examples tambien! ****
        routeGroup.MapGet("/test2/{id}/data", GetTest2Data)
            .WithName("GetTest2Data")
            .Produces<MyError>(StatusCodes.Status400BadRequest);

        return app;
    }

    /// <summary>GET test1/{id}/data.</summary>
    /// <remarks>Endpoint de prueba para verificar conectividad.</remarks>
    /// <param name="id" example="Abc123">ID único del elemento a recuperar.</param>
    /// <response code="200">Éxito: Elemento encontrado.</response>
    /// <response code="400">Request inválido. Devuelve MyError.</response>
    public static string GetTest2Data(string id, HttpContext httpContext)
    {
        return "Test 2 API ok";
    }
}
