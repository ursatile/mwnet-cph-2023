using Rockaway.WebApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
var clock = new SystemClock();
builder.Services.AddSingleton<IClock>(clock);
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseRouting();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapGet("/hello", () => "Hello World!");
app.Run();