using MovieApi.Application.Features.CQRSDesignPattern.Queries.CastQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.CastResults;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CastHandlers;

public class GetCastByIdQueryHandler
{
    private readonly MovieContext _context;

    public GetCastByIdQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery query)
    {
        var values = await _context.Casts.FindAsync(query.CastId);
        return new GetCastByIdQueryResult
        {
            CastId = values.CastId,
            ImageUrl = values.ImageUrl,
            Biography = values.Biography,
            Overview = values.Overview,
            Title = values.Title,
            Name = values.Name,
            Surname = values.Surname,
            

        };
    }
}