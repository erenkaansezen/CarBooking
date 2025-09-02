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
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCarCommand command)
        {
            var car = await _repository.GetByIdAsync(command.CarID);
            if (car != null)
            {
                car.Fuel = command.Fuel;
                car.Transmission = command.Transmission;
                car.BıgImageUrl = command.BıgImageUrl;
                car.BrandID = command.BrandID;
                car.CoverImageUrl = command.CoverImageUrl;
                car.Km = command.Km;
                car.Luggage = command.Luggage;
                car.Model = command.Model;
                car.Seat = command.Seat;
                await _repository.UpdateAsync(car);
            }
        }
    }
}
