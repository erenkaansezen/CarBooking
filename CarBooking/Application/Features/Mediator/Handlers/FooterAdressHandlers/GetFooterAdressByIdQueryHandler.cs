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
    public class GetFooterAdressByIdQueryHandler : IRequestHandler<GetFooterAdressByIdQuery, GetFooterAdressByIdQueryResult>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAdressByIdQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterAdressByIdQueryResult> Handle(GetFooterAdressByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetFooterAdressByIdQueryResult
            {
                FooterAddressID = value.FooterAddressID,
                Description = value.Description,
                Adress = value.Adress,
                Phone = value.Phone,
                Email = value.Email
            };
        }
    }
}
