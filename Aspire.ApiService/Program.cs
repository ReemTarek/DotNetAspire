using Aspire.ApiService;
using Aspire.ApiService.Data;
using Aspire.ApiService.DbAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();
//register countries service
//builder.Services.AddDbContext<AspireAPIDbContext>(opt =>
//{
//    opt.UseSqlServer(builder.Configuration.GetConnectionString("AspireAPI"));
//});
builder.AddSqlServerClient("AspireAPICon");

builder.AddSqlServerDbContext<AspireAPIDbContext>("AspireAPICon");

//builder.Services.AddSingleton<ISqlDbContext, SqlDbContext>();
//builder.Services.AddScoped<ICountriesData, CountriesData>();
builder.Services.AddScoped<ICountriesService, CountriesService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});
//added to configure api
app.ConfigureApi();
app.MapDefaultEndpoints();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
