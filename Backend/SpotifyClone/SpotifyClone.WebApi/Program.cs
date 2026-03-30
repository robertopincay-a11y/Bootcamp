using SpotifyClone.Application.Interfaces.Services;
using SpotifyClone.Application.Services;
using SpotifyClone.Domain.Entities;
using SpotifyClone.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddSingleton<Cache<User>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
