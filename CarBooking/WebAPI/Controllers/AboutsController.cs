using Application.Features.CQRS.Commands.AboutCommands;
using Application.Features.CQRS.Handlers.AboutHandlers;
using Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly GetAboutQueryHandler _getAboutQueryHandler;
        private readonly GetAboutByIdQueryHandler _getByIdHandler;     
        private readonly CreateAboutCommandHandler _createHandler;
        private readonly UpdateAboutCommandHandle _updateHandler;
        private readonly RemoveAboutCommandHandler _removeHandler;

        public AboutsController(RemoveAboutCommandHandler removeHandler, GetAboutQueryHandler getAboutQueryHandler, GetAboutByIdQueryHandler getByIdHandler, CreateAboutCommandHandler createHandler = null, UpdateAboutCommandHandle updateHandler = null)
        {
            _removeHandler = removeHandler;
            _getAboutQueryHandler = getAboutQueryHandler;
            _getByIdHandler = getByIdHandler;
            _createHandler = createHandler;
            _updateHandler = updateHandler;
        }
        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var about = await _getAboutQueryHandler.Handle();
            return Ok(about);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var about = await _getByIdHandler.Handle( new GetAboutByIdQuery(id));
            return Ok(about);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            await _createHandler.Handle(command);
            return Ok("Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAbout(int id)
        {
            await _removeHandler.Handle(new RemoveAboutCommand(id));
            return Ok("Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            await _updateHandler.Handle(command);
            return Ok("Güncellendi");
        }
    }
}
