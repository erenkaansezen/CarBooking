using Application.Features.Mediator.Queries.PricingQueries;
using Application.Features.Mediator.Queries.ServiceQueries;
using Application.Features.Mediator.Results.PricingResults;
using Application.Features.Mediator.Results.ServiceResults;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceQueryHandler(IRepository<Service> Repository)
        {
            _repository = Repository;
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetServiceQueryResult
            {
                ServiceID = x.ServiceID,
                Title = x.Title,
                Description = x.Description,
                IconUrl = x.IconUrl
            }).ToList();
        }
    }
}
