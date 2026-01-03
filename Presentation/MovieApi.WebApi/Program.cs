using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.Handlers;
using MovieApi.Persistance.Context;

namespace MovieApi.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<MovieContext>();

        // CQRS Handlers
        builder.Services.AddScoped<GetCategoryQueryHandler>();
        builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
        builder.Services.AddScoped<CreateCategoryCommandHandler>();
        builder.Services.AddScoped<UpdateCategoryCommandHandler>();
        builder.Services.AddScoped<RemoveCategoryCommandHandler>();

        builder.Services.AddScoped<GetMovieQueryHandler>();
        builder.Services.AddScoped<GetMovieByIdQueryHandler>();
        builder.Services.AddScoped<CreateMovieCommandHandler>();
        builder.Services.AddScoped<UpdateMovieCommandHandler>();
        builder.Services.AddScoped<RemoveMovieCommandHandler>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(); // 🔥 PARAMETRESİZ

        var app = builder.Build();

        app.UseSwagger();     // 🔥 HER ZAMAN
        app.UseSwaggerUI();   // 🔥 HER ZAMAN

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}