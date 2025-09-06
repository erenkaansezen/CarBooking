using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Mediator.Commands.ReservationCommands;
using Application.Features.Mediator.Commands.TestimonialCommands;
using Application.Interfaces;
using MediatR;
using Web.Domain.Entities;

namespace Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class RemoveReservationCommandHandler : IRequestHandler<RemoveReservationCommand>
    {
        private readonly IRepository<Reservation> _repository;

        public RemoveReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _repository.GetByIdAsync(request.ReservationID);
            if (reservation != null)
            {
                await _repository.DeleteAsync(reservation);
            }
        }
    }
}
