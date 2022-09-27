using Microsoft.EntityFrameworkCore;
using ToDo.Repositories;
using ToDo.Repositories.Abstract;
using ToDo.Services;
using ToDo.Services.Abstract;
using TodoApi.Services;
using NLog;
using Contracts;
using Todo.Common;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<TodoContext>(opt =>
//    opt.UseInMemoryDatabase("TodoList"));
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TodoContext>(options =>
    options.UseSqlServer(connString));

builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
builder.Services.AddScoped<ITodoItemsRepository, TodoItemsRepository>();
builder.Services.AddScoped<ITodoItemsService, TodoItemsService>();
builder.Services.AddScoped<IModelValidations, ModelValidations>();

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
