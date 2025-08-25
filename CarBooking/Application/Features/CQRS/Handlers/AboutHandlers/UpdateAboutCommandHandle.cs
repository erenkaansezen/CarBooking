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
    public class UpdateAboutCommandHandle
    {
        private readonly IRepository<About> _repository;
        public UpdateAboutCommandHandle(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAboutCommand command)
        {
            var about = await _repository.GetByIdAsync(command.Id);
            if (about != null)
            {
                about.Title = command.Title;
                about.Description = command.Description;
                about.ImageUrl = command.ImageUrl;
                await _repository.UpdateAsync(about);
            }
        }
    }
}
