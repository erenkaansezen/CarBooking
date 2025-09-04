using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Mediator.Commands.CarFeatureCommands;
using Application.Interfaces.CarFeatureInterfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class UpdateCarFeatureAvaibleToTrueCommandHandler : IRequestHandler<UpdateCarFeatureAvaibleToTrueCommand>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public UpdateCarFeatureAvaibleToTrueCommandHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }
        public async Task Handle(UpdateCarFeatureAvaibleToTrueCommand request, CancellationToken cancellationToken)
        {
            _carFeatureRepository.ChangeCarFeatureAvailableToTrue(request.Id);
        }
    }
}
