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
    public class RemoveServiceCommandHandler : IRequestHandler<RemoveServiceCommand>
    {
        private readonly IRepository<Service> _repository;

        public RemoveServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
        {
            var Location = await _repository.GetByIdAsync(request.Id);
            if (Location != null)
            {
                await _repository.DeleteAsync(Location);
            }
        }
    }
}
}
