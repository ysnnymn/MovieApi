using MovieApi.Application.Features.CQORSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQORSDesignPattern.Handlers.MovieHandlers;

public class RemoveMovieCommandHandler
{
    private readonly MovieContext _context;

    public RemoveMovieCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async void Handle(RemoveMovieCommand command)
    {
        var movie = await _context.Movies.FindAsync(command.MovieId);
        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();
    }
}