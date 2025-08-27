using Application.Features.Mediator.Commands.PricingCommands;
using Application.Features.Mediator.Commands.ServiceCommands;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
    {
        private readonly IRepository<Service> _repository;
        public CreateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            Service service = new Service
            {
                Title = request.Title,
                Description = request.Description,               
                IconUrl = request.IconUrl
            };
            await _repository.AddAsync(service);
        }
    }
}
