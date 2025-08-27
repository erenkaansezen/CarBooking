using Application.Features.Mediator.Commands.ServiceCommands;
using Application.Features.Mediator.Commands.SocialMediaCommands;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class RemoveSocialMediaCommandHandler : IRequestHandler<RemoveSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _repository;

        public RemoveSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var socialMedia = await _repository.GetByIdAsync(request.Id);
            if (socialMedia != null)
            {
                await _repository.DeleteAsync(socialMedia);
            }
        }
    }
}
