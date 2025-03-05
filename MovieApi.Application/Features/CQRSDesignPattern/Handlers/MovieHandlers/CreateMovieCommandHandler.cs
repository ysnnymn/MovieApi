using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;

public class CreateMovieCommandHandler
{
    private readonly MovieContext _context;

    public CreateMovieCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(CreateMovieCommand createMovieCommand)
    {
        _context.Movies.Add(new Movie()
        {
            Title = createMovieCommand.Title,
            Description = createMovieCommand.Description,
            ReleaseDate = createMovieCommand.ReleaseDate,
            CoverImageUrl = createMovieCommand.CoverImageUrl,
            CreatedYear = createMovieCommand.CreatedYear,
            Duration = createMovieCommand.Duration,
            Raiting = createMovieCommand.Raiting,
            Status = createMovieCommand.Status

        });
        await _context.SaveChangesAsync();
    }
}