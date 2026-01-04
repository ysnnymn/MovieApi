using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.SeriesCommands;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.SeriesHandlers;

public class RemoveSeriesCommandHandler:IRequestHandler<RemoveSeriesCommand>
{
    private readonly MovieContext _context;

    public RemoveSeriesCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveSeriesCommand request, CancellationToken cancellationToken)
    {
        var value = await _context.Series.FindAsync(request.SeriesId);
        _context.Series.Remove(value);
        await _context.SaveChangesAsync();
    }
}