using MovieApi.Application.Features.CQRSDesignPattern.Commands.CastCommands;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CastHandlers;

public class UpdateCastCommandHandler
{
    private readonly MovieContext _context;

    public UpdateCastCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCastCommand command)
    {
        var value = await _context.Casts.FindAsync(command.CastId);
        value.Biography = command.Biography;
        value.Name = command.Name;
        value.Surname = command.Surname;
        value.Overview = command.Overview;
        value.Title=command.Title;
        value.ImageUrl=command.ImageUrl;
        await _context.SaveChangesAsync();
        
    }
    
}