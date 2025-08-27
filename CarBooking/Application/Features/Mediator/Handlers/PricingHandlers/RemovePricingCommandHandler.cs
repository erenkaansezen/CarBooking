using Application.Features.Mediator.Commands.LocaitonCommands;
using Application.Features.Mediator.Commands.PricingCommands;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Application.Features.Mediator.Handlers.PricingHandlers
{
    public class RemovePricingCommandHandler : IRequestHandler<RemovePricingCommand>
    {
        private readonly IRepository<Pricing> _repository;

        public RemovePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemovePricingCommand request, CancellationToken cancellationToken)
        {
            var Location = await _repository.GetByIdAsync(request.Id);
            if (Location != null)
            {
                await _repository.DeleteAsync(Location);
            }
        }
    }
}
