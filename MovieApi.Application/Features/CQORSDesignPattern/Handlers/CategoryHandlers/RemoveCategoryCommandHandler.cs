using MovieApi.Application.Features.CQORSDesignPattern.Commands.CategoryCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQORSDesignPattern.Handlers.CategoryHandlers;

public class RemoveCategoryCommandHandler
{
    private readonly MovieContext _context;

    public RemoveCategoryCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async void Handle(RemoveCategoryCommand command)
    {
        var category = await _context.Categories.FindAsync(command.CategoryId);
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }
}