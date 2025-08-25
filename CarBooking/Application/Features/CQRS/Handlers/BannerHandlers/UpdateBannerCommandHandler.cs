using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.CQRS.Commands.AboutCommands;
using Application.Features.CQRS.Commands.BannerCommands;
using Application.Interfaces;
using Web.Domain.Entities;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBannerCommand command)
        {
            var banner = await _repository.GetByIdAsync(command.BannerId);
            if (banner != null)
            {
                banner.Title = command.Title;
                banner.Description = command.Description;
                banner.VideoDescription = command.VideoDescription;
                banner.VideoUrl = command.VideoUrl;
                await _repository.UpdateAsync(banner);
            }
        }
    }
}
