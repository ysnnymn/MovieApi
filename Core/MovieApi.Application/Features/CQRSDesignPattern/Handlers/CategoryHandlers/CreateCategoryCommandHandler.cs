using MovieApi.Domain.Entities;
using MovieApi.Domain.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.Handlers;

public class CreateCategoryCommandHandler
{
    private readonly MovieContext _context;

    public CreateCategoryCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(CreateCategoryCommand command)
    {
        _context.Categories.Add(new Category
        {
            CategoryName = command.CategoryName
        });
        await _context.SaveChangesAsync();
    }
}