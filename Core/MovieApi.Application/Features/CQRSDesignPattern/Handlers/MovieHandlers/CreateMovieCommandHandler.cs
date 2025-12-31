using MovieApi.Domain.Entities;
using MovieApi.Domain.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;

public class CreateMovieCommandHandler
{
    private readonly MovieContext _context;

    public CreateMovieCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async void Handle(CreateMovieCommand command)
    {
        _context.Movies.Add(new Movie
        {
            CoverImageUrl = command.CoverImageUrl,
            Description = command.Description,
            CreatedYear = command.CreatedYear,
            Duration = command.Duration,
            Raitng = command.Raitng,
            RealeseDate = command.RealeseDate,
            Status = command.Status,
            Title = command.Title,

        });
        await _context.SaveChangesAsync();
    }
}