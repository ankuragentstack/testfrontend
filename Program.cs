var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

// Listen on 8080 in containers (ACA), 5000 locally
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

var app = builder.Build();

app.UseStaticFiles();
app.MapRazorPages();

app.MapGet("/api/time", () => new { time = DateTime.Now.ToString("hh:mm:ss tt, dddd dd MMMM yyyy") });

app.Run();
