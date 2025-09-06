using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Mediator.Commands.ReservationCommands
{
    public class RemoveReservationCommand : IRequest
    {
        public int ReservationID { get; set; }
        public RemoveReservationCommand(int reservationID)
        {
            ReservationID = reservationID;
        }
    }
}
