using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Domain.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Domain.Features.CQRSDesignPattern.Queries.MovieQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly GetMovieQueryHandler _getMovieQueryHandler;
        private readonly CreateMovieCommandHandler _createMovieCommandHandler;
        private readonly UpdateMovieCommandHandler _updateMovieCommandHandler;
        private readonly RemoveMovieCommandHandler _removeMovieCommandHandler;
        private readonly GetMovieByIdQueryHandler _getMovieByIdQueryHandler;
        private readonly GetMovieWithCategoryQueryHandler _getMovieWithCategoryQueryHandler;

        public MoviesController(GetMovieQueryHandler getMovieQueryHandler, CreateMovieCommandHandler createMovieCommandHandler, UpdateMovieCommandHandler updateMovieCommandHandler, RemoveMovieCommandHandler removeMovieCommandHandler, GetMovieByIdQueryHandler getMovieByIdQueryHandler, GetMovieWithCategoryQueryHandler getMovieWithCategoryQueryHandler)
        {
            _getMovieQueryHandler = getMovieQueryHandler;
            _createMovieCommandHandler = createMovieCommandHandler;
            _updateMovieCommandHandler = updateMovieCommandHandler;
            _removeMovieCommandHandler = removeMovieCommandHandler;
            _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
            _getMovieWithCategoryQueryHandler = getMovieWithCategoryQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> MovieList()
        {
            var value = await _getMovieQueryHandler.Handle();
            return Ok(value);
        }

        [HttpGet("GetMovie")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var value = await _getMovieByIdQueryHandler.Handle(new GetMovieByIdQuery(id ));
            return Ok(value);
        }

     
        [HttpPost]
        public async Task<IActionResult> CreateMovies(CreateMovieCommand commands)
        {
           
                await _createMovieCommandHandler.Handle(commands);
            
            return Ok("Movies created");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateMovie(UpdateMovieCommand command)
        {
            await _updateMovieCommandHandler.Handle(command);
            return Ok("Movie updated");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveMovie(int id)
        {
            await _removeMovieCommandHandler.Handle(new RemoveMovieCommand(id));
            return Ok("Movie removed");
        }

        [HttpGet("GetMovieWithCategory")]
        public async Task<IActionResult> GetMovieWithCategory()
        {
            var value=await _getMovieWithCategoryQueryHandler.Handle();
            return Ok(value);
        }
    }
    
   
    

}
