using Microsoft.EntityFrameworkCore;
using MovieApi.Domain.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;

public class GetMovieQueryHandler
{
    private readonly MovieContext _context;

    public GetMovieQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<List<GetMovieQueryResult>> Handle()
    {
        var values = await _context.Movies.ToListAsync();
        return values.Select(x => new GetMovieQueryResult
        {
            MovieId = x.MovieId,
            Title = x.Title,
            CoverImageUrl = x.CoverImageUrl,
            CreatedYear = x.CreatedYear,
            Description = x.Description,
            Duration = x.Duration,
            Raitng = x.Raitng,
            RealeseDate = x.RealeseDate,
            Status = x.Status,
        }).ToList();
    }
}