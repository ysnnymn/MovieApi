using MovieApi.Application.Features.CQRSDesignPattern.Commands.CastCommands;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CastHandlers;

public class RemoveCastCommandHandler
{
    private readonly MovieContext _context;

    public RemoveCastCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveCastCommand command)
    {
        var value= await _context.Casts.FindAsync(command.CastId);
        _context.Casts.Remove(value);
        await _context.SaveChangesAsync();
    }
}