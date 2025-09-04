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
    public class UpdateCarFeatureAvaibleToFalseCommandHandler : IRequestHandler<UpdateCarFeatureAvaibleToFalseCommand>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public UpdateCarFeatureAvaibleToFalseCommandHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task Handle(UpdateCarFeatureAvaibleToFalseCommand request, CancellationToken cancellationToken)
        {
            _carFeatureRepository.ChangeCarFeatureAvailableToFalse(request.Id);
        }
    }
}
