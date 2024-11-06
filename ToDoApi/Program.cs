using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

//Setup database connection and provider
var connectionString = "Data Source=ToDo.db";
builder.Services.AddSqlite<ApplicationDBContext>(connectionString);

builder.Services.AddControllers();

var app = builder.Build();

//Ensure the db is created at startup
var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDBContext>();
context.Database.EnsureCreated();

app.MapGet("/", () => "Hello World!");
app.MapControllers();

app.Run();
