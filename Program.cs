using dotnet.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<BookDto> books = [
    new (
        1,
        "Steal Like an Artist",
        "Self-help",
        9.99M,
        new DateOnly(2012, 2, 28)
    ),
    new (
        2,
        "Rich Dad Poor Dad",
        "Personal-finance",
        14.48M,
        new DateOnly(1997, 4, 14)
    ),
    new (
        3,
        "It Ends with Us",
        "Romance",
        9.03M,
        new DateOnly(2017, 8, 2)

    ),
    new (
        4,
        "Atomic Habits",
        "Self-help",
        14.20M,
        new DateOnly(2018, 10, 16)

    ),
    new (
        5,
        "It Starts with Us",
        "Romance",
        7.67M,
        new DateOnly(2022, 10, 18)

    ),
    new (
        6,
        "The 5 AM Club",
        "Self-help",
        15.50M,
        new DateOnly(2018, 12, 4)

    ),
];

app.MapGet("/", () => "Hello World!");
app.MapGet("/sara", () => "Hello sara!");

app.Run();
