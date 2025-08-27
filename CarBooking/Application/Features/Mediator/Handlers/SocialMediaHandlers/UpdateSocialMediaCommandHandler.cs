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
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _repository;

        public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var socialMedia = await _repository.GetByIdAsync(request.SocialMediaID);
            if (socialMedia != null)
            {
                socialMedia.Name = request.Name;
                socialMedia.Url = request.Url;
                socialMedia.IconUrl = request.IconUrl;
                await _repository.UpdateAsync(socialMedia);
            }
        }
    }
}
