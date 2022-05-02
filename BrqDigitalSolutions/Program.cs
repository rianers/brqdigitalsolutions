using DotNetEnv;
using BrqDigitalSolutions.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

DotNetEnv.Env.Load();

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<BaseContext>(options =>
{
  var database = Environment.GetEnvironmentVariable("DB_DATABASE");
  var username = Environment.GetEnvironmentVariable("DB_USERNAME");
  var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
  var host = Environment.GetEnvironmentVariable("DB_HOSTNAME");
  var port = Environment.GetEnvironmentVariable("DB_PORT");

  options.UseNpgsql($"Host={host};Port={port};Database={database};Username={username};Password={password}");
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
