using Microsoft.EntityFrameworkCore;
using ToDo.Repositories;
using ToDo.Repositories.Abstract;
using ToDo.Services;
using ToDo.Services.Abstract;
using TodoApi.Services;
using NLog;
using Contracts;
using Todo.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TodoApi.Middlware;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TodoContext>(options =>
    options.UseSqlServer(connString));


builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
builder.Services.AddScoped<ITodoItemsRepository, TodoItemsRepository>();
builder.Services.AddScoped<ITodoItemsService, TodoItemsService>();
builder.Services.AddScoped<IModelValidations, ModelValidations>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<UserContext, UserContext>();
builder.Services.AddScoped<IToolService, ToolService>();
builder.Services.AddScoped<IToolRepository, ToolRepository>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseErrorHandlingMiddleware();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseContextMiddleware();

app.Run();
