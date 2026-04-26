var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles();
app.MapRazorPages();

app.MapGet("/api/time", () => new { time = DateTime.Now.ToString("hh:mm:ss tt, dddd dd MMMM yyyy") });

app.Run();
