# TimeApp

A minimal ASP.NET Core Razor Pages app with a button that fetches the current server time via a backend API call.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Run

```bash
cd TimeApp
dotnet run
```

Then open `http://localhost:5000` in your browser.

## How it works

| Layer | File | Role |
|-------|------|------|
| Backend API | `Program.cs` | `GET /api/time` returns current server time as JSON |
| Page | `Pages/Index.cshtml` | Button + JS `fetch()` call to `/api/time` |
| Styles | `wwwroot/site.css` | Simple centered card layout |
