using Microsoft.AspNetCore.Identity;
using MovieApi.Persistance.Context;
using MovieApi.Persistance.Identity;
using MovieApi.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<MovieContext>();

// Identity
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<MovieContext>();

// Application Services (CQRS, MediatR, AutoMapper)
builder.Services.AddApplicationServices();

// Controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.Run();