using Application.Features.Mediator.Queries.FooterAdressQueries;
using Application.Features.Mediator.Queries.LocationQueries;
using Application.Features.Mediator.Results.FooterAdressResults;
using Application.Features.Mediator.Results.LocationResults;
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
    class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
    {
        private readonly IRepository<Location> _repository;

        public GetLocationQueryHandler(IRepository<Location> Repository)
        {
            _repository = Repository;
        }

        public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetLocationQueryResult
            {
                LocationID = x.LocationID,
                Name = x.Name,
                LocationUrl = x.LocationUrl
            }).ToList();
        }
    }
}

