using Application.Features.Mediator.Commands.FooterAdressCommands;
using Application.Features.Mediator.Commands.LocaitonCommands;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Application.Features.Mediator.Handlers.LocationHandlers
{
    class RemoveLocationCommandHandler : IRequestHandler<RemoveLocationCommand>
    {
        private readonly IRepository<Location> _repository;

        public RemoveLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
        {
            var Location = await _repository.GetByIdAsync(request.Id);
            if (Location != null)
            {
                await _repository.DeleteAsync(Location);
            }
        }
    }
}
