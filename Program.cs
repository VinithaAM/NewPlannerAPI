using Microsoft.EntityFrameworkCore;
using NewPlannerAPI.Domain.Models;
using NewPlannerAPI.Domain.Services;
using NewPlannerAPI.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

var connectionString = configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPlannerCommand, PlannerCommand>();
builder.Services.AddScoped<IPlannerQuery, PlannerQuery>();
builder.Services.AddCors(options =>
options.AddPolicy(name: "AllowOrigin",
policy =>
{
    policy.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowOrigin");

app.MapPost("api/Planner/Create", (IPlannerCommand hd, PlannerHeader plannerHeader) =>
{
    try
    {

        return hd.Create(plannerHeader);
    }
    catch (Exception )
    {
        throw ;
    }
});
app.MapPut("api/Planner/Update", (IPlannerCommand pl,PlannerHeader plannerHeader) =>
{
    try
    {
        return pl.Update(plannerHeader);
    }
    catch (Exception )
    {
        throw ;
    }
});
app.MapGet("api/Planner/GetById", (IPlannerQuery pl, int id) =>
{
    try
    {
        return pl.GetById(id);
    }
    catch (Exception )
    {
        throw;
    }
});
app.MapGet("api/Planner/Get", (IPlannerQuery pl) =>
{
    try
    {
        return pl.GetAll();
    }
    catch (Exception )
    {
        throw ;
    }
});
app.MapDelete("api/Planner/Delete", (IPlannerCommand pl, int id) =>
{
    try
    {
        return pl.Delete(id);
    }
    catch (Exception)
    {
        throw;
    }
});

app.Run();

//internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateTime.Now.AddDays(index),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast");