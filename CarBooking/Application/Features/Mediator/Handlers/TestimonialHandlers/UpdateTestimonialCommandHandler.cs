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
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var testimonial = await _repository.GetByIdAsync(request.TestimonialID);
            if (testimonial != null)
            {
                testimonial.Name = request.Name;
                testimonial.Title = request.Title;
                testimonial.Comment = request.Comment;
                testimonial.ImageUrl = request.ImageUrl;
                await _repository.UpdateAsync(testimonial);
            }
        }
    }
}
