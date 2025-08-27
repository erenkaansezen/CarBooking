using Application.Features.Mediator.Commands.FooterAdressCommands;
using Application.Features.Mediator.Queries.FooterAdressQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAdressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAdressController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAdresses()
        {
            var result = await _mediator.Send(new GetFooterAdressQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdressById(int id)
        {
            var value = await _mediator.Send(new GetFooterAdressByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdress(CreateFooterAdressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Adress eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAdress(UpdateFooterAdressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Adress güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdress(int id)
        {
            await _mediator.Send(new RemoveFooterAdressCommand(id));
            return Ok("Adress silindi");
        }
    }
}
