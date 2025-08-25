using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.CQRS.Queries.BrandQueries;
using Application.Features.CQRS.Queries.CarQueries;
using Application.Features.CQRS.Result.BrandResults;
using Application.Features.CQRS.Result.CarResults;
using Application.Interfaces;
using Web.Domain.Entities;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;
        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetCarByIdQueryResult
            {
                BrandID = value.BrandID,
                CarID = value.CarID,
                CoverImageUrl = value.CoverImageUrl,
                Fuel = value.Fuel,
                BıgImageUrl = value.BıgImageUrl,
                Km = value.Km,
                Luggage = value.Luggage,
                Model = value.Model,
                Seat = value.Seat,
                Transmission = value.Transmission

            };
        }
    }
}
