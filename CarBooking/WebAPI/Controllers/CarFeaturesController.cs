using Application.Features.Mediator.Commands.CarFeatureCommands;
using Application.Features.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarFeaturesByCarId(int id)
        {
            var result = await _mediator.Send(new GetCarFeatureByIdQuery(id));
            return Ok(result);
        }
        [HttpGet("CarFeatureChangeAvaibleFalse")]
        public async Task<IActionResult> CarFeatureChangeAvaibleFalse(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvaibleToFalseCommand(id));
            return Ok("Güncelleme Yapıldı");
        }
        [HttpGet("CarFeatureChangeAvaibleTrue")]
        public async Task<IActionResult> CarFeatureChangeAvaibleTrue(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvaibleToTrueCommand(id));
            return Ok("Güncelleme Yapıldı");
        }
    }
}
