using Microsoft.EntityFrameworkCore;
using XivVoicesService;
using XivVoicesService.Models;

// Load .env
var projectRoot = Directory.GetParent(Directory.GetCurrentDirectory())?.FullName;
if (projectRoot != null) {
    DotEnv.Load(Path.Combine(projectRoot, ".env"));
}

// Config
var config = new ConfigurationBuilder().AddEnvironmentVariables().Build();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB Connection Info
var dbHost = config["POSTGRES_HOST"] ?? throw new ArgumentNullException("config[\"POSTGRES_HOST\"]");
var dbPort = config["POSTGRES_PORT"] ?? throw new ArgumentNullException("config[\"POSTGRES_PORT\"]");
var dbName = config["POSTGRES_DB"] ?? throw new ArgumentNullException("config[\"POSTGRES_DB\"]");
var dbUsername = config["POSTGRES_USER"] ?? throw new ArgumentNullException("config[\"POSTGRES_USER\"]");
var dbPassword = config["POSTGRES_PASSWORD"] ?? throw new ArgumentNullException("config[\"POSTGRES_PASSWORD\"]");

// Add db contexts
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseNpgsql($"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUsername};Password={dbPassword}")
);

// Add repositories
builder.Services.AddScoped<IReportRepository, ReportRepository>();

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