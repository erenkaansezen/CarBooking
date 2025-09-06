using Application.Features.CQRS.Handlers.ReservationHandlers;
using Application.Features.Mediator.Commands.CarFeatureCommands;
using Application.Features.Mediator.Commands.ReservationCommands;
using Application.Features.Mediator.Commands.TestimonialCommands;
using Application.Features.Mediator.Queries.FeatureQueries;
using Application.Features.Mediator.Queries.ReservationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllReservation()
        {
            var result = await _mediator.Send(new GetReservationQuery());
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Rezervasyon oluşturuldu");
        }

        [HttpPost("ReservationStatusToDelivered/{id}")]
        public async Task<IActionResult> ReservationStatusToDelivered(int id)
        {
            _mediator.Send(new UpdateReservationStatusDeliveredCommand(id));
            return Ok("Güncelleme Yapıldı");
        }
        [HttpPost("ReservationStatusToReceived/{id}")]
        public async Task<IActionResult> ReservationStatusToReceived(int id)
        {
            _mediator.Send(new UpdateReservationStatusReceivedCommand(id));
            return Ok("Güncelleme Yapıldı");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            await _mediator.Send(new RemoveReservationCommand(id));
            return Ok("Rezervasyon silindi");
        }
    }
}
