using dotnet.Data;
using dotnet.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var connectionString = builder.Configuration.GetConnectionString("BookCon");
builder.Services.AddSqlite<BookContext>(connectionString);

app.MapBooksEndpoints();

app.MapGet("/", () => "Hello World!");
app.MapGet("/sara", () => "Hello sara!");

app.Run();
