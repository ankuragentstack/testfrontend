var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

var backendUrl = Environment.GetEnvironmentVariable("BACKEND_URL") ?? "http://localhost:8080";
builder.Services.AddHttpClient("backend", c => c.BaseAddress = new Uri(backendUrl));

// Listen on 8080 in containers (ACA), 5000 locally
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

var app = builder.Build();

app.UseStaticFiles();
app.MapRazorPages();

app.MapGet("/api/time", () => new { time = DateTime.Now.ToString("hh:mm:ss tt, dddd dd MMMM yyyy") });

app.MapGet("/api/timezone/{**tz}", async (string tz, IHttpClientFactory factory) =>
{
    var client = factory.CreateClient("backend");
    var response = await client.GetAsync($"/config/v1/testTime/{tz}");
    var body = await response.Content.ReadAsStringAsync();
    return Results.Content(body, "application/json", statusCode: (int)response.StatusCode);
});

app.Run();
