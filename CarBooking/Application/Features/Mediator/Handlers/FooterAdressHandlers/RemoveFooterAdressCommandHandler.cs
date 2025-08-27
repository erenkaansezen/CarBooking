using Application.Features.Mediator.Commands.FeatureCommands;
using Application.Features.Mediator.Commands.FooterAdressCommands;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Application.Features.Mediator.Handlers.FooterAdressHandlers
{
    public class RemoveFooterAdressCommandHandler : IRequestHandler<RemoveFooterAdressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;

        public RemoveFooterAdressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveFooterAdressCommand request, CancellationToken cancellationToken)
        {
            var feature = await _repository.GetByIdAsync(request.Id);
            if (feature != null)
            {
                await _repository.DeleteAsync(feature);
            }
        }
    }
}
