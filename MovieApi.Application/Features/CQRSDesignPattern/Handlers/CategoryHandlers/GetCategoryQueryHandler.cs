
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.CategoryResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;

public class GetCategoryQueryHandler
{
    private readonly MovieContext _context;

    public GetCategoryQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<List<GetCategoryQueryResult>> Handle()
    {
        var values = await _context.Categories.ToListAsync();
        return values.Select(x => new GetCategoryQueryResult
        {
            CategoryId = x.CategoryId,
            CategoryName = x.CategoryName,

        }).ToList();
    }
}