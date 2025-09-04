using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Mediator.Queries.CarPricingQueries;
using Application.Features.Mediator.Results.CarPricingResults;
using Application.Features.Mediator.Results.LocationResults;
using Application.Interfaces;
using Application.Interfaces.CarPricingInterfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingQueryHandler : IRequestHandler<GetCarPricingQuery, List<GetCarPricingQueryResult>>
    {
        private readonly ICarPricingRepository _repository;
        public GetCarPricingQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _repository = carPricingRepository;
        }

        public async Task<List<GetCarPricingQueryResult>> Handle(GetCarPricingQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarPricingWithCars();
            return values.Select(x => new GetCarPricingQueryResult
            {
                Amount = x.Amount,
                CarPricingId = x.CarPricingID,
                CarId = x.CarID,
                CoverImageUrl = x.Car.CoverImageUrl,
                Brand = x.Car.Brand.Name,
                Model = x.Car.Model
            }).ToList();
        }
    }
}
