using Microsoft.EntityFrameworkCore;
using XivVoicesService.Models;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Services
builder.Services.AddDbContext<XivVoicesServiceDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("XivVoicesService")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
