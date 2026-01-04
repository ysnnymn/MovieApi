using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.SeriesQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.SeriesResults;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.SeriesHandlers;

public class GetSeriesQueryHandler:IRequestHandler<GetSeriesQuery,List<GetSeriesQueryResult>>
{
    private readonly IMapper _mapper;
    private readonly MovieContext _context;

    public GetSeriesQueryHandler(IMapper mapper, MovieContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<List<GetSeriesQueryResult>> Handle(GetSeriesQuery request, CancellationToken cancellationToken)
    {
        var values = await _context.Series.ToListAsync();
        return _mapper.Map<List<GetSeriesQueryResult>>(values);
        
    }
}