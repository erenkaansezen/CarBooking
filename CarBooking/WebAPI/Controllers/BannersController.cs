using Application.Features.CQRS.Commands.BannerCommands;
using Application.Features.CQRS.Handlers.BannerHandlers;
using Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly GetBannerQueryHandler _getBannerQueryHandler;
        private readonly GetBannerByIdQueryHandler _getByIdHandler;
        private readonly CreateBannerCommandHandler _createHandler;
        private readonly UpdateBannerCommandHandler _updateHandler;
        private readonly RemoveBannerCommandHandler _removeHandler;

        public BannersController(GetBannerQueryHandler getBannerQueryHandler, GetBannerByIdQueryHandler getByIdHandler, CreateBannerCommandHandler createHandler, UpdateBannerCommandHandler updateHandler, RemoveBannerCommandHandler removeHandler)
        {
            _getBannerQueryHandler = getBannerQueryHandler;
            _getByIdHandler = getByIdHandler;
            _createHandler = createHandler;
            _updateHandler = updateHandler;
            _removeHandler = removeHandler;
        }
        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var banners = await _getBannerQueryHandler.Handle();
            return Ok(banners);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var banner = await _getByIdHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(banner);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await _createHandler.Handle(command);
            return Ok("Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            await _removeHandler.Handle(new RemoveBannerCommand(id));
            return Ok("Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await _updateHandler.Handle(command);
            return Ok("Güncellendi");
        }
    }
}
