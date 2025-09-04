using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Mediator.Queries.RentCarQueries;
using Application.Features.Mediator.Results.RentCarResults;
using Application.Interfaces.RentACarInterfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.RentCarHandlers
{
    public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
    {
        private readonly IRentACarRepository _rentACarRepository;

        public GetRentACarQueryHandler(IRentACarRepository rentACarRepository)
        {
            _rentACarRepository = rentACarRepository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = await _rentACarRepository.GetByFilterAsync(x => x.LocationId == request.LocationId && x.Available == true);
            return values.Select(y => new GetRentACarQueryResult
            {
                CarId = y.CarId,
                Brand = y.Car.Brand.Name,
                Model = y.Car.Model,
                CoverImageUrl = y.Car.CoverImageUrl,
            }).ToList();
            
        }
    }
}
