using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.SeriesCommands;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.SeriesQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SeriesesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> SeriesList()
        {
            var value = await _mediator.Send(new GetSeriesQuery());
            return Ok(value);
        }

        [HttpGet("GetSeries/{id}")]
        public async Task<IActionResult> GetSeries(int id)
        {
            var value = await _mediator.Send(new GetSeriesByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeries(CreateSeriesCommand command)
        {
             await _mediator.Send(command);
             return Ok("Series created");
            
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSeries(UpdateSeriesCommand command)
        {
            await _mediator.Send(command);
            return Ok("Series updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeries(int id)
        {
            await _mediator.Send(new RemoveSeriesCommand(id));
            return Ok("Series deleted");
        }
        
    }
}
