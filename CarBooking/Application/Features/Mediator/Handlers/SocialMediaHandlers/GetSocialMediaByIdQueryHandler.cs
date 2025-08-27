using Application.Features.Mediator.Queries.ServiceQueries;
using Application.Features.Mediator.Queries.SocaialMediaQueries;
using Application.Features.Mediator.Results.ServiceResults;
using Application.Features.Mediator.Results.SocaimalMediaResults;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetSocialMediaByIdQueryResult
            {
                SocialMediaID = value.SocialMediaID,
                Name = value.Name,
                Url = value.Url,
                IconUrl = value.IconUrl
            };
        }
    }
}
