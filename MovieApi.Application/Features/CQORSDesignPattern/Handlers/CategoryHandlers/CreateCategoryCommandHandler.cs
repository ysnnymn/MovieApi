using MovieApi.Application.Features.CQORSDesignPattern.Commands.CategoryCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQORSDesignPattern.Handlers.CategoryHandlers;

public class CreateCategoryCommandHandler
{
    private readonly MovieContext _context;

    public CreateCategoryCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async void Handle(CreateCategoryCommand createCategoryCommand)
    {
        _context.Categories.Add(new Category
        {
            CategoryName = createCategoryCommand.CategoryName,
            
        });
       await _context.SaveChangesAsync();
    }
}