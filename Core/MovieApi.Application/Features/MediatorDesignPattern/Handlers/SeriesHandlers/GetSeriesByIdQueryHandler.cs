using AutoMapper;
using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.SeriesQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.SeriesResults;
using MovieApi.Persistance.Context;


namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.SeriesHandlers;

public class GetSeriesByIdQueryHandler:IRequestHandler<GetSeriesByIdQuery,GetSeriesByIdQueryResult>
{
    private readonly IMapper _mapper;
    private readonly MovieContext _context;

    public GetSeriesByIdQueryHandler(IMapper mapper, MovieContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<GetSeriesByIdQueryResult> Handle(GetSeriesByIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _context.Series.FindAsync(request.SeriesId);
        var result=_mapper.Map<GetSeriesByIdQueryResult>(values);
        return result;
        
    }
}