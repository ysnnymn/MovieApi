using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Results.SeriesResults;

namespace MovieApi.Application.Features.MediatorDesignPattern.Queries.SeriesQueries;

public class GetSeriesQuery:IRequest<List<GetSeriesQueryResult>>
{
    
}