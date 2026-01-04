using AutoMapper;
using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.SeriesCommands;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.SeriesHandlers;

public class UpdateSeriesCommandHandler : IRequestHandler<UpdateSeriesCommand>
{
    private readonly IMapper _mapper;
    private readonly MovieContext _context;

    public UpdateSeriesCommandHandler(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Handle(UpdateSeriesCommand request, CancellationToken cancellationToken)
    {
        var series = await _context.Series.FindAsync(request.SeriesId);

        if (series == null)
            throw new Exception("Series bulunamadı");

        _mapper.Map(request, series);

        await _context.SaveChangesAsync(cancellationToken);
    }
}