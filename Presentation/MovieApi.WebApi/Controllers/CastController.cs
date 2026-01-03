using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.CastCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.CastHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.CastQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.CastResults;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastController : ControllerBase
    {
        private readonly GetCastQueryHandler _castQueryHandler;
        private readonly GetCastByIdQueryHandler _castByIdQueryHandler;
        private readonly CreateCastCommandHandler _createCastCommandHandler;
        private readonly UpdateCastCommandHandler _updateCastCommandHandler;
        private readonly RemoveCastCommandHandler _removeCastCommandHandler;

        public CastController(GetCastQueryHandler castQueryHandler, GetCastByIdQueryHandler castByIdQueryHandler, CreateCastCommandHandler createCastCommandHandler, UpdateCastCommandHandler updateCastCommandHandler, RemoveCastCommandHandler removeCastCommandHandler)
        {
            _castQueryHandler = castQueryHandler;
            _castByIdQueryHandler = castByIdQueryHandler;
            _createCastCommandHandler = createCastCommandHandler;
            _updateCastCommandHandler = updateCastCommandHandler;
            _removeCastCommandHandler = removeCastCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> CastList()
        {
            var value=await _castQueryHandler.Handle();
            return Ok(value);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> CastById(int id)
        {
            var value = await _castByIdQueryHandler.Handle(new GetCastByIdQuery(id));
            return Ok(value);
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateCast(CreateCastCommand command)
        {
            await _createCastCommandHandler.Handle(command);
            return Ok("Cast created");
            
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCast(UpdateCastCommand command)
        {
             await _updateCastCommandHandler.Handle(command);
             return Ok("Cast updated");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCast(int id)
        {
            await _removeCastCommandHandler.Handle(new RemoveCastCommand(id));
            return Ok("Cast removed");
            
        }
       
    }
}
