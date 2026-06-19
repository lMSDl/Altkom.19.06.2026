using Models;
using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<ICrudService<User>>(_ =>
    new InMemoryCrudService<User>(u => u.Id, (u, id) => u.Id = id));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// MinimalAPI - Informacje o wersji serwisu
app.MapGet("/api/version", () =>
{
    var version = new
    {
        service = "WebApp",
        version = "1.0.0",
        buildDate = DateTime.UtcNow.ToString("o"),
        environment = app.Environment.EnvironmentName,
        dotnetVersion = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription
    };
    return Results.Ok(version);
})
.WithName("GetVersion")
.WithDescription("Zwraca informacje o wersji i konfiguracji serwisu");

app.MapControllers();

app.Run();
