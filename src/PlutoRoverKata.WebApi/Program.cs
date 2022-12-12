using PlutoRoverKata.NavigationSystem;
using PlutoRoverKata.NavigationSystem.Entities;
using PlutoRoverKata.NavigationSystem.Enums;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddNavigator(builder.Configuration);

builder.Services
    .AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(o =>
    {
        o.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Pluto Rover Kata", Version = "v1" });
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
