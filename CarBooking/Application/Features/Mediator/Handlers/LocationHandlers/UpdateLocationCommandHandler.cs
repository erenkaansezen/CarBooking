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
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
    {
        private readonly IRepository<Location> _repository;

        public UpdateLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await _repository.GetByIdAsync(request.LocationID);
            if (location != null)
            {
                location.Name = request.Name;
                location.LocationUrl = request.LocationUrl;
                await _repository.UpdateAsync(location);
            }
        }
    }
}
