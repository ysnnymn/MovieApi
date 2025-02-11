using MovieApi.Application.Features.CQORSDesignPattern.Commands.MovieCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQORSDesignPattern.Handlers.MovieHandlers;

public class UpdateMovieCommandHandler
{
    private readonly MovieContext _context;

    public UpdateMovieCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async void Handler(UpdateMovieCommand command)
    {
        var value = await _context.Movies.FindAsync(command.MovieId);
        value.Title = command.Title;
        value.Description = command.Description;
        value.Status = command.Status;
        value.Duration = command.Duration;
        value.Raiting=command.Raiting;
        value.ReleaseDate = command.ReleaseDate;
        value.CoverImageUrl=command.CoverImageUrl;
        value.CreatedYear=command.CreatedYear;
        await _context.SaveChangesAsync();
            
    }
}