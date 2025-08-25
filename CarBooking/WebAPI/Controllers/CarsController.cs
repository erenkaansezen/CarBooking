using Application.Features.CQRS.Commands.CarCommands;
using Application.Features.CQRS.Handlers.CarHandlers;
using Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetCarWithCarQueryHandler _getCarWithCarQueryHandler;
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;


        public CarsController(
            GetCarQueryHandler getCarQueryHandler,
            GetCarByIdQueryHandler getCarByIdQueryHandler,
            CreateCarCommandHandler createCarCommandHandler,
            UpdateCarCommandHandler updateCarCommandHandler,
            RemoveCarCommandHandler removeCarCommandHandler,
            GetCarWithCarQueryHandler getCarWithCarQueryHandler)
        {
            _getCarQueryHandler = getCarQueryHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _createCarCommandHandler = createCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _getCarWithCarQueryHandler = getCarWithCarQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var result = await _getCarQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var result = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handle(command);
            return Ok("Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _updateCarCommandHandler.Handle(command);
            return Ok("Güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCar(int id)
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok("Silindi");
        }
        [HttpGet("GetCarWithBrand")]
        public async Task<IActionResult> GetCarWithBrand()
        {
            var result = _getCarWithCarQueryHandler.Handle();
            return Ok(result);
        }
    }
}
