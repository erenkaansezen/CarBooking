using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Mediator.Queries.CarFeatureQueries;
using Application.Features.Mediator.Results.CarFeatureResults;
using Application.Features.Mediator.Results.LocationResults;
using Application.Interfaces;
using Application.Interfaces.CarFeatureInterfaces;
using MediatR;
using Web.Domain.Entities;

namespace Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureByIdQueryHandler : IRequestHandler<GetCarFeatureByIdQuery, List<GetCarFeatureByIdQueryResult>>
    {
        private readonly ICarFeatureRepository _repository;
        public GetCarFeatureByIdQueryHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCarFeatureByIdQueryResult>> Handle(GetCarFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var value =  _repository.GetCarFeaturesByIdCar(request.Id);
            return value.Select(x=> new GetCarFeatureByIdQueryResult
            {
                Available = x.Available,
                CarFeatureID = x.CarFeatureID,
                FeatureID = x.FeatureID,
                FeatureName = x.Feature.Name,
            }).ToList();
        }
    }
}
