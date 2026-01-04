using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using MovieApi.Domain.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;

public class GetMovieWithCategoryQueryHandler
{
    private readonly MovieContext _context;

    public GetMovieWithCategoryQueryHandler(MovieContext context)
    {
        _context = context;
    }
    public async Task<List<GetMovieWithCategoryQueryResult>> Handle()
    {
        var values = await _context.Movies.Include(x=>x.Category).ToListAsync();
        return values.Select(x => new GetMovieWithCategoryQueryResult
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
            CategoryId = x.CategoryId,
            CategoryName = x.Category.CategoryName
        }).ToList();
    }
}