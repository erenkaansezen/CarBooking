using Application.Features.CQRS.Commands.BrandCommands;
using Application.Features.CQRS.Handlers.BrandHandlers;
using Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly GetBrandQueryHandler _getBrandQueryHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;
        public BrandsController(GetBrandQueryHandler getBrandQueryHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler, CreateBrandCommandHandler createBrandCommandHandler, UpdateBrandCommandHandler updateBrandCommandHandler, RemoveBrandCommandHandler removeBrandCommandHandler)
        {
            _getBrandQueryHandler = getBrandQueryHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            _createBrandCommandHandler = createBrandCommandHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var result = await _getBrandQueryHandler.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var result = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
        {
            await _createBrandCommandHandler.Handle(command);
            return Ok("Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
        {
            await _updateBrandCommandHandler.Handle(command);
            return Ok("Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
            return Ok("Silindi");
        }



    }
}
