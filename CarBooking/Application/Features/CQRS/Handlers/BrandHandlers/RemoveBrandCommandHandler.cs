using Application.Features.CQRS.Commands.BannerCommands;
using Application.Features.CQRS.Commands.BrandCommands;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class RemoveBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;
        public RemoveBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveBrandCommand remove)
        {
            var banner = await _repository.GetByIdAsync(remove.Id);
            if (banner != null)
            {
                await _repository.DeleteAsync(banner);
            }
        }
    }
}
