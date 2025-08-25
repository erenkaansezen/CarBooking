using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.CQRS.Commands.BrandCommands;
using Application.Features.CQRS.Commands.CarCommands;
using Application.Interfaces;
using Web.Domain.Entities;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class RemoveCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        public RemoveCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveCarCommand remove)
        {
            var banner = await _repository.GetByIdAsync(remove.Id);
            if (banner != null)
            {
                await _repository.DeleteAsync(banner);
            }
        }
    }
}
