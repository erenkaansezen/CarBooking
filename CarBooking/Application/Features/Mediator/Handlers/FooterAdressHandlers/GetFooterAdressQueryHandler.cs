using Application.Features.Mediator.Queries.FeatureQueries;
using Application.Features.Mediator.Queries.FooterAdressQueries;
using Application.Features.Mediator.Results.FeatureResults;
using Application.Features.Mediator.Results.FooterAdressResults;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Application.Features.Mediator.Handlers.FooterAdressHandlers
{
    public class GetFooterAdressQueryHandler : IRequestHandler<GetFooterAdressQuery, List<GetFooterAdressQueryResult>>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAdressQueryHandler(IRepository<FooterAddress> Repository)
        {
            _repository = Repository;
        }

        public async Task<List<GetFooterAdressQueryResult>> Handle(GetFooterAdressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFooterAdressQueryResult
            {
                FooterAddressID = x.FooterAddressID,
                Description = x.Description,
                Adress = x.Adress,
                Phone = x.Phone,
                Email = x.Email
            }).ToList();
        }
    }
}
