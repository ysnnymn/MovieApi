using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Results.SeriesResults;

namespace MovieApi.Application.Features.MediatorDesignPattern.Queries.SeriesQueries;

public class GetSeriesByIdQuery:IRequest<GetSeriesByIdQueryResult>
{
    public GetSeriesByIdQuery(int seriesId)
    {
        SeriesId = seriesId;
    }

    public int SeriesId { get; set; }
   
}