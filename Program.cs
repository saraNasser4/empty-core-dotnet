using dotnet.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapBooksEndpoints();

app.MapGet("/", () => "Hello World!");
app.MapGet("/sara", () => "Hello sara!");

app.Run();
