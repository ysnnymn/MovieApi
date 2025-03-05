using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;

public class GetMovieQueryHandler
{private readonly MovieContext _context;

    public GetMovieQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<List<GetMovieQueryResult>> Handle()
    {
        var value = await _context.Movies.ToListAsync();
        return value.Select(x => new GetMovieQueryResult
        {
            MovieId = x.MovieId,
            CoverImageUrl = x.CoverImageUrl,
            CreatedYear = x.CreatedYear,
            Description = x.Description,
            Duration = x.Duration,
            Raiting = x.Raiting,
            Title = x.Title,
            ReleaseDate = x.ReleaseDate,
            Status = x.Status,

        }).ToList();
    }
}