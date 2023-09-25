using System;
using Microsoft.EntityFrameworkCore;
using PaymentGetaway.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Fetch the connection string
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Check if environment variables are set and overwrite the connection string if they are
string dbHost = Environment.GetEnvironmentVariable("DATABASE_HOST");
string dbPort = Environment.GetEnvironmentVariable("DATABASE_PORT");
string dbName = Environment.GetEnvironmentVariable("DATABASE_NAME");
string dbUser = Environment.GetEnvironmentVariable("DB_USERNAME") ?? Environment.GetEnvironmentVariable("DATABASE_USER");
string dbPass = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? Environment.GetEnvironmentVariable("DATABASE_PASSWORD");

if (!string.IsNullOrEmpty(dbHost) && !string.IsNullOrEmpty(dbUser) && !string.IsNullOrEmpty(dbPass))
{
    connectionString = $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPass};SslMode=Prefer";
}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (string.IsNullOrEmpty(builder.Configuration["ASPNETCORE_URLS"]))
{
    app.Urls.Add("http://*:80");
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
