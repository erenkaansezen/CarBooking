using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.CQRS.Commands.BrandCommands;
using Application.Features.CQRS.Commands.CarCommands;
using Application.Interfaces;
using Web.Domain.Entities;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateCarCommand command)
        {
            Car car = new Car
            {
                BıgImageUrl = command.BıgImageUrl,
                Luggage = command.Luggage,
                Km = command.Km,
                Model = command.Model,
                Seat = command.Seat,
                Transmission = command.Transmission,
                CoverImageUrl = command.CoverImageUrl,
                BrandID = command.BrandID,
                Fuel = command.Fuel
            };
            await _repository.AddAsync(car);
        }
    }
}
