using Application.Features.Mediator.Commands.SocialMediaCommands;
using Application.Features.Mediator.Commands.TestimonialCommands;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class RemoveTestimonialCommandHandler : IRequestHandler<RemoveTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public RemoveTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
        {
            var socialMedia = await _repository.GetByIdAsync(request.TestimonialID);
            if (socialMedia != null)
            {
                await _repository.DeleteAsync(socialMedia);
            }
        }
    }
}
