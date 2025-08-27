using Application.Features.Mediator.Queries.LocationQueries;
using Application.Features.Mediator.Queries.PricingQueries;
using Application.Features.Mediator.Results.LocationResults;
using Application.Features.Mediator.Results.PricingResults;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Application.Features.Mediator.Handlers.PricingHandlers
{
    public class GetPricingQueryHandler : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
    {
        private readonly IRepository<Pricing> _repository;

        public GetPricingQueryHandler(IRepository<Pricing> Repository)
        {
            _repository = Repository;
        }

        public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetPricingQueryResult
            {
                PricingID = x.PricingID,
                Name = x.Name
            }).ToList();
        }
    }
}
