using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.CQRS.Queries.BrandQueries;
using Application.Features.CQRS.Result.BrandResults;
using Application.Features.CQRS.Result.CarResults;
using Application.Interfaces;
using Web.Domain.Entities;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _repository;
        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCarQueryResult
            {
                BrandID = x.BrandID,
                BıgImageUrl = x.BıgImageUrl,
                CarID = x.CarID,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Seat = x.Seat,
                Model = x.Model,
                Transmission = x.Transmission,

            }).ToList();
        }
    }
}
