using Microsoft.EntityFrameworkCore;
using System.IO;
using System;
using Cookify.Common;

string currentDir = AppContext.BaseDirectory;
while (currentDir != null && Directory.GetFiles(currentDir, "*.sln").Length == 0)
{
    currentDir = Directory.GetParent(currentDir)?.FullName;
}
if (currentDir != null)
{
    string dbPath = Path.Combine(currentDir, "DB");
    Directory.CreateDirectory(dbPath);
    AppDomain.CurrentDomain.SetData("DataDirectory", dbPath);
}

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.RegisterSystemServices(connectionString);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseAuthorization();
app.MapControllers();

DependencyContainer.InitializeDatabase(app.Services);

app.Run();