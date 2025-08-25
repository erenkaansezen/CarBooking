using Application.Features.CQRS.Queries.BannerQueries;
using Application.Features.CQRS.Result.BannerResults;
using Application.Features.CQRS.Result.BrandResults;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler
    {
        private readonly IRepository<Brand> _repository;
        public GetBrandByIdQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
        public async Task<GetBrandByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetBrandByIdQueryResult
            {
                BrandID = value.BrandID,
                Name = value.Name
            };
        }
    }
}
