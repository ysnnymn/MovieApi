using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;

public class UpdateMovieCommandHandler
{
    private readonly MovieContext _context;

    public UpdateMovieCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateMovieCommand command)
    {
        var value = await _context.Movies.FindAsync(command.MovieId);
        value.Title = command.Title;
        value.Description = command.Description;
        value.Raiting=command.Raiting;
        value.Status=command.Status;
        value.Duration=command.Duration;
        value.CoverImageUrl = command.CoverImageUrl;
        value.CreatedYear=command.CreatedYear;
        value.ReleaseDate=command.ReleaseDate;
        await _context.SaveChangesAsync();
        
        
    }
}