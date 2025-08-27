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
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly IRepository<Service> _repository;

        public UpdateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _repository.GetByIdAsync(request.ServiceID);
            if (service != null)
            {
                service.Title = request.Title;
                service.Description = request.Description;
                service.IconUrl = request.IconUrl;
                await _repository.UpdateAsync(service);
            }
        }
    }
}
