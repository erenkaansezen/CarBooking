using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.CQRS.Commands.BannerCommands;
using Application.Interfaces;
using Web.Domain.Entities;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class RemoveBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;
        public RemoveBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveBannerCommand remove)
        {
            var banner = await _repository.GetByIdAsync(remove.Id);
            if (banner != null)
            {
                await _repository.DeleteAsync(banner);
            }
        }
    }
}
