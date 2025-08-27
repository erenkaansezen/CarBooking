using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Mediator.Commands.FeatureCommands;
using Application.Interfaces;
using MediatR;
using Web.Domain.Entities;

namespace Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommands>
    {
        private readonly IRepository<Feature> _repository;
        public CreateFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateFeatureCommands request, CancellationToken cancellationToken)
        {
            Feature feature = new Feature
            {
                Name = request.Name,
            };
            await _repository.AddAsync(feature);
        }
    }
}
