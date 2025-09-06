using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Mediator.Commands.ReservationCommands;
using Application.Interfaces.ReservationInterfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class UpdateReservationStatusReceivedCommandHandler : IRequestHandler<UpdateReservationStatusReceivedCommand>
    {
        private readonly IReservationRepository _reservationRepository;

        public UpdateReservationStatusReceivedCommandHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task Handle(UpdateReservationStatusReceivedCommand request, CancellationToken cancellationToken)
        {
            _reservationRepository.UpdateReservationStatusToReceived(request.Id);
        }
    }
}
