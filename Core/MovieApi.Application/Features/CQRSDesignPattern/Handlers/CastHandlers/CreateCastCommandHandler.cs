using MovieApi.Application.Features.CQRSDesignPattern.Commands.CastCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CastHandlers;

public class CreateCastCommandHandler
{
    private readonly MovieContext _context;

    public CreateCastCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(CreateCastCommand createCastCommand)
    {

        _context.Casts.Add(new Cast
        {
            Title = createCastCommand.Title,
            Name = createCastCommand.Name,
            Surname = createCastCommand.Surname,
            ImageUrl = createCastCommand.ImageUrl,
            Overview = createCastCommand.Overview,
            Biography = createCastCommand.Biography,

        });
        await _context.SaveChangesAsync();
    }
}