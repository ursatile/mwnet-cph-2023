var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Results.File("form.html", "text/html"));
app.MapPost("/calculate", (HttpContext ctx) => {
    Int32.TryParse(ctx.Request.Form["x"], out int x);
    Int32.TryParse(ctx.Request.Form["y"], out int y);
    var op = ctx.Request.Form["op"].Single();
    var result = op switch {
        "*" => x * y,
        "-" => x - y,
        "/" => x /y ,
        _ => x + y
    };
    return Results.Content($"<!DOCTYPE html><html><body>The result is: {result}<hr /><small>Powered by World's Dumbest Calculator!/<small></body></html>", "text/html");
});


// app.MapGet("/hello/{name}", (string name) => $"Hello {name}!");
// app.MapGet("/hei/{name}", (string name) => $"Hei {name}!");
// app.MapGet("/multiply/{x}/{y}", (int x, int y) => x * y);
// app.MapGet("/multiply", (int x, int y) => x * y);
// app.MapGet("/object", () => new { greeting = "Hello", who = "Copenhagen" });
// app.MapGet("/form", () => Results.File("form.html", "text/html"));
app.Run();
