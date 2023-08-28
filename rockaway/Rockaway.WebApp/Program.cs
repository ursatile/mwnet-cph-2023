var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
var app = builder.Build();

// Add routing support used by Razor Pages
app.UseRouting();
// Map requests to Razor pages
app.MapRazorPages();

app.MapGet("/hello", () => "Hello World!");

app.Run();
