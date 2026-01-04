using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.TagResults;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandlers;

public class GetTagQueryHandler:IRequestHandler<GetTagQuery, List<GetTagQueryResult>>
{
    private readonly MovieContext _context;

    public GetTagQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<List<GetTagQueryResult>> Handle(GetTagQuery request, CancellationToken cancellationToken)
    {
        var value =  await _context.Tags.ToListAsync();
        return value.Select(x => new GetTagQueryResult
        {
            Title = x.Title,
            TagId = x.TagId

        }).ToList();

    }
}