var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/hello/{name}", (string name) => $"Hello {name}!");
app.MapGet("/hei/{name}", (string name) => $"Hei {name}!");
app.MapGet("/multiply/{x}/{y}", (int x, int y) => x * y);
app.MapGet("/multiply", (int x, int y) => x * y);
app.MapGet("/object", () => new { greeting = "Hello", who = "Copenhagen" });
app.MapGet("/form", () => Results.File("form.html", "text/html"));
app.Run();
