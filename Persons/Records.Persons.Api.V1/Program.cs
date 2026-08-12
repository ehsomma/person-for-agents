using Microsoft.OpenApi;
using Records.Persons.Api.V1.Endpoints;
using Records.Shared.Http.DependencyIjection;

namespace Records.Persons.Api.V1;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // https://localhost:____/openapi/v1.json
        // https://localhost:____/swagger
        // NOTE: No hace falta agregar archivos XML de otros proyectos, los reconoce automáticamente
        // si el proyecto los genera. Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi("v1", options =>
        {
            options.AddDocumentTransformer((doc, ctx, ct) =>
            {
                doc.Info = new OpenApiInfo
                {
                    Title = "Demo Minimal API",
                    Version = "v1",
                    Description = "Mi API minimal documentada",
                };
                return Task.CompletedTask;
            });
        });

        builder.Services.AddEndpointsApiExplorer(); // Enables API explorer for endpoints.

        WebApplication app = builder.Build();

        ////app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        app.UseGlobalExceptionHandler();

        // Configure the HTTP request pipeline.
        app.MapOpenApi();

        app.UseHttpsRedirection();
        app.UseAuthorization();

        // Mapea los endpoints.
        app.MapPersonasEndpoints();

        app.Run();
    }
}
