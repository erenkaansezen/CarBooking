using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.CQRS.Commands.AboutCommands;
using Application.Interfaces;
using Web.Domain.Entities;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class RemoveAboutCommandHandler
    {
        private readonly IRepository<About> _repository;
        public RemoveAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveAboutCommand command)
        {
            var about = await _repository.GetByIdAsync(command.Id);
            if (about != null)
            {
                await _repository.DeleteAsync(about);
            }
        }
    }
}
