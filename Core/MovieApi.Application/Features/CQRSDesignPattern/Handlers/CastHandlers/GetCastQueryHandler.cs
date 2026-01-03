using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.CastResults;
using MovieApi.Domain.Features.CQRSDesignPattern.Results.CategoryResults;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CastHandlers;

public class GetCastQueryHandler
{
    private readonly MovieContext _context;

    public GetCastQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<List<GetCastQueryResult>> Handle()
    {
        var values = await _context.Casts.ToListAsync();
        return values.Select(x => new GetCastQueryResult
        {
            CastId = x.CastId,
            Name = x.Name,
            Surname = x.Surname,
            Title = x.Title,
            Biography = x.Biography,
            Overview = x.Overview,
            ImageUrl = x.ImageUrl,
            
        }).ToList();
    }
}