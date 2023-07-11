using Application.Interface.Repository;
using Application.Interface.Service;
using AutoMapper;
using FluentValidation;
using infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Ocelot.Values;
using System;
using System.Text;
using Task.Application.Mapping;
using Task.Domain.Domain.Entities;
using Task.infrastructure.Services;
using Task.Rest.Api.Middlewares;
using Microsoft.AspNetCore.Identity;
using Task.Application.Validation;
using Task.Rest.Api.Filters;
using Microsoft.AspNetCore.Authorization;
using Task.Rest.Api.Health;
using Microsoft.AspNetCore.Builder;
using System.Data;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITaskRepo,TaskRepo>();
builder.Services.AddScoped<ITaskService,TaskService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register the PostgreSQL connection
builder.Services.AddScoped<IDbConnection>(provider => new NpgsqlConnection(connectionString));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("woopsy", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.Requirements.Add(new FailRequirement());
    });
});
builder.Services.AddTransient<IAuthorizationHandler, FailHandler>();
builder.Services.AddSingleton<IAuthorizationMiddlewareResultHandler, AuthorizationMiddlewareResultHandler>();
builder.Services.AddScoped<IValidator<User>, UserValidator>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                      });
});
builder.Services.AddHealthChecks()
    .AddCheck<MyHealthCheck>("my-health-check");

builder.Services.AddScoped<ActioFilter>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();
app.Run();
