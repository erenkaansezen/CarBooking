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
    public class CreateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public CreateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateAboutCommand command)
        {
            About about = new About
            {
                Title = command.Title,
                Description = command.Description,
                ImageUrl = command.ImageUrl
            };
            await _repository.AddAsync(about);
        }
    }
}
