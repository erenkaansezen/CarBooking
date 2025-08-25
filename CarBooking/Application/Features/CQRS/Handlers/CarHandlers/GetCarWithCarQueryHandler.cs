using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.CQRS.Result.CarResults;
using Application.Interfaces;
using Application.Interfaces.CarInterfaces;
using Web.Domain.Entities;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithCarQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarWithCarQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public List<GetCarWithBrandQueryResult> Handle()
        {
            var values =  _repository.GetCarsListWithBrand();
            return values.Select(x => new GetCarWithBrandQueryResult
            {
                BrandID = x.BrandID,
                BrandName = x.Brand.Name,
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
