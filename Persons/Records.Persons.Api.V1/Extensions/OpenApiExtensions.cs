#region Usings

using System.Text.Json.Nodes;
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

            options.AddSchemaTransformer((schema, context, cancellationToken) =>
            {
                FixTypedExamples(schema);
                return Task.CompletedTask;
            });
        });

        return services;
    }

    #endregion

    #region Private methods

    /// <summary>
    /// Fix para que en los ejemplos de entidades (los que se ven en Scalar) no ponga "True" (con comillas) en lugar
    /// de `true` sin comillas.
    /// </summary>
    /// <param name="schema">The Schema Object allows the definition of input and output data types.</param>
    private static void FixTypedExamples(OpenApiSchema schema)
    {
        if (schema.Properties is null)
        {
            return;
        }

        foreach (var (_, propSchema) in schema.Properties)
        {
            if (propSchema is not OpenApiSchema concrete) continue;
            if (concrete.Example is not JsonValue value) continue;
            if (!value.TryGetValue<string>(out var text)) continue; // solo si quedó como string

            // El tipo del schema lo puso el generador antes que nosotros.
            concrete.Example = concrete.Type switch
            {
                JsonSchemaType.Boolean when bool.TryParse(text, out var b)
                    => JsonValue.Create(b),
                JsonSchemaType.Integer when long.TryParse(text, out var l)
                    => JsonValue.Create(l),
                JsonSchemaType.Number when decimal.TryParse(text, System.Globalization.CultureInfo.InvariantCulture, out var d)
                    => JsonValue.Create(d), _ => concrete.Example, // string, guid, fecha: se quedan como están
            };
        }
    }

    #endregion
}
