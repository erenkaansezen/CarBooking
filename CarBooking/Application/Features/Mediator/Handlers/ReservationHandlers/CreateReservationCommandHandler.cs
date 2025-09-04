using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Mediator.Commands.ReservationCommands;
using Application.Interfaces;
using MediatR;
using Web.Domain.Entities;

namespace Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IRepository<Reservation> _repository;

        public CreateReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(new Reservation
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                Phone = request.Phone,
                PickUpLocationID = request.PickUpLocationID,
                DropOffLocationID = request.DropOffLocationID,
                CarID = request.CarID,
                Age = request.Age,
                DriverLicenseYear = request.DriverLicenseYear,
                Description = request.Description,
                Status = "Rezervasyon Alındı"
            });
        }
    }
}
