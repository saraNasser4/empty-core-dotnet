using dotnet.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetBookEndpointName = "GetBook";

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

// GET
app.MapGet("/books", () => books);
app.MapGet("/books/{id}", (int id) => books.Find(book => book.Id == id)).WithName(GetBookEndpointName);

// POSt
app.MapPost("/books", (CreateBookDto newBook) =>
{
    BookDto book = new(
        books.Count + 1,
        newBook.Name,
        newBook.Genre,
        newBook.Price,
        newBook.ReleaseDate
    );

    books.Add(book);

    return Results.CreatedAtRoute(GetBookEndpointName, new { id = book.Id }, book);
});

// PUT
app.MapPut("/books/{id}", (int id, UpdateBookDto updatedBook) =>
{
    var index = books.FindIndex(book => book.Id == id);
    books[index] = new BookDto(
        id,
        updatedBook.Name,
        updatedBook.Genre,
        updatedBook.Price,
        updatedBook.ReleaseDate
    );

    return Results.NoContent();
});

// DELETE
app.MapDelete("/books/{id}", (int id)=>
{
    books.RemoveAll(book => book.Id == id);
    return Results.NoContent();
});

app.MapGet("/", () => "Hello World!");
app.MapGet("/sara", () => "Hello sara!");

app.Run();
