using AutoMapper;
using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.SeriesCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.SeriesHandlers;

public class CreateSeriesCommandHandler:IRequestHandler<CreateSeriesCommand>
{
    
    private readonly MovieContext _context;
    private readonly IMapper _mapper;

    public CreateSeriesCommandHandler(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Handle(CreateSeriesCommand request, CancellationToken cancellationToken)
    {
       var series=_mapper.Map<Series>(request);
       _context.Series.Add(series);
       await _context.SaveChangesAsync();
    }
}

