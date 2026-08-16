#region Usings

using Microsoft.OpenApi;

#endregion

namespace Records.Persons.Api.V1.Extensions;

/// <summary>
/// Extensions methods for dependency injection.
/// </summary>
internal static class OpenApiExtensions
{
    #region Public methods

    /// <summary>
    /// Configures and registers OpenAPI document generation for the API.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The same service collection.</returns>
    public static IServiceCollection AddOpenApiCustom(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        // https://localhost:____/openapi/v1.json
        // NOTE: No hace falta agregar archivos XML de otros proyectos, los reconoce automáticamente
        // si el proyecto los genera. Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        services.AddOpenApi("v1", options =>
        {
            options.AddDocumentTransformer((doc, ctx, ct) =>
            {
                doc.Info = new OpenApiInfo
                {
                    Title = "Demo proyecto Persons",
                    Version = "v1",
                    Description = "Proyecto modelo base aplicando estándares de estructura, " +
                                  "codificación, reglas y documentación de código.",
                };
                return Task.CompletedTask;
            });
        });

        return services;
    }

    #endregion
}
