using Application.Features.Mediator.Queries.RentCarQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RentACarsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetRentACarByLocation(int locationID,bool available)
        {
            GetRentACarQuery getRentACarQuery = new GetRentACarQuery()
            {
                LocationId = locationID,
                Avaible = available
            };
            var result = await _mediator.Send(getRentACarQuery);
            return Ok(result);
        }
    }
}
