using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MovieApi.Application.Mapping;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.CastHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.UserRegisterHandlers;
using MovieApi.Application.Features.Handlers;
using MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandlers;
using System.Reflection;

namespace MovieApi.WebApi.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // -----------------------------
        // CQRS HANDLERS
        // -----------------------------
        services.AddScoped<GetCategoryQueryHandler>();
        services.AddScoped<GetCategoryByIdQueryHandler>();
        services.AddScoped<CreateCategoryCommandHandler>();
        services.AddScoped<UpdateCategoryCommandHandler>();
        services.AddScoped<RemoveCategoryCommandHandler>();

        services.AddScoped<GetMovieQueryHandler>();
        services.AddScoped<GetMovieByIdQueryHandler>();
        services.AddScoped<CreateMovieCommandHandler>();
        services.AddScoped<UpdateMovieCommandHandler>();
        services.AddScoped<RemoveMovieCommandHandler>();
        services.AddScoped<GetMovieWithCategoryQueryHandler>();

        services.AddScoped<GetCastQueryHandler>();
        services.AddScoped<GetCastByIdQueryHandler>();
        services.AddScoped<CreateCastCommandHandler>();
        services.AddScoped<UpdateCastCommandHandler>();
        services.AddScoped<RemoveCastCommandHandler>();

        services.AddScoped<CreateUserRegisterCommandHandler>();

        // -----------------------------
        // MediatR
        // -----------------------------
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetTagQueryHandler).Assembly));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCastCommandHandler).Assembly));

        // -----------------------------
        // AutoMapper
        // -----------------------------
        services.AddAutoMapper(typeof(SeriesProfile).Assembly);

        return services;
    }
}
