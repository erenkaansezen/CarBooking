using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Mediator.Commands.CarFeatureCommands;
using Application.Features.Mediator.Commands.ReservationCommands;
using Application.Interfaces.CarFeatureInterfaces;
using Application.Interfaces.ReservationInterfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class UpdateReservationStatusDeliveredCommandHandler : IRequestHandler<UpdateReservationStatusDeliveredCommand>
    {
        private readonly IReservationRepository _reservationRepository;

        public UpdateReservationStatusDeliveredCommandHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task Handle(UpdateReservationStatusDeliveredCommand request, CancellationToken cancellationToken)
        {
            _reservationRepository.UpdateReservationStatusToDelivered(request.Id);
        }
    }
}
