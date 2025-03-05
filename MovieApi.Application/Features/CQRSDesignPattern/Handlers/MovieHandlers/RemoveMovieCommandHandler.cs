using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;

public class RemoveMovieCommandHandler
{
    private readonly MovieContext _context;

    public RemoveMovieCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveMovieCommand command)
    {
        var value=_context.Movies.FindAsync(command.MovieId);
        _context.Remove(value);
        await _context.SaveChangesAsync();
        
    }
}