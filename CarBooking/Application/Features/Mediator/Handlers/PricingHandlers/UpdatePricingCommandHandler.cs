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
    public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand>
    {
        private readonly IRepository<Pricing> _repository;

        public UpdatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
            var location = await _repository.GetByIdAsync(request.PricingID);
            if (location != null)
            {
                location.Name = request.Name;
                await _repository.UpdateAsync(location);
            }
        }
    }
}
