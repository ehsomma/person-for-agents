using Records.Persons.Api.V1.Endpoints;
using Records.Persons.Api.V1.Extensions;
using Records.Persons.Shared.Configuration.DependencyInjection;
using Records.Shared.Http;
using Records.Shared.Serilog.DependencyInjection;
using Scalar.AspNetCore;
////using Serilog;

namespace Records.Persons.Api.V1;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Configures and registers Serilog as the logger.
        builder.AddSerilogCustom();

        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Configura y registra la generación del documento OpenAPI.
        builder.Services.AddOpenApiCustom();

        // Enables API explorer for endpoints.
        builder.Services.AddEndpointsApiExplorer();

        // Registers the necessary configurations with the DI framework.
        builder.Services.AddConfiguration(builder.Configuration);

        WebApplication app = builder.Build();

        // Builder vacío: nuestro handler escribe la respuesta. Sin esto y al no usar el estándar
        // `ProblemDetails` para devolver errores, falla al arrancar.
        app.UseExceptionHandler(_ => { });

        // Configure the HTTP request pipeline.
        app.MapOpenApi();

        // UI en /scalar/v1.
        app.MapScalarApiReference();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        ////app.UseSerilogRequestLogging();

        // Mapea los endpoints.
        app.MapPersonasEndpoints();

        app.Run();
    }
}
