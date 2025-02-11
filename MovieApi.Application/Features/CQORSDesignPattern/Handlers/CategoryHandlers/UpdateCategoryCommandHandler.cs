using MovieApi.Application.Features.CQORSDesignPattern.Commands.CategoryCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQORSDesignPattern.Handlers.CategoryHandlers;

public class UpdateCategoryCommandHandler
{
    private readonly MovieContext _context;

    public UpdateCategoryCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async void Handle(UpdateCategoryCommand command)
    {
        var value = await _context.Categories.FindAsync(command.CategoryId);
        value.CategoryName=command.CategoryName;
        await _context.SaveChangesAsync();
         
    }
}