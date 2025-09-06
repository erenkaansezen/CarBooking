using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Mediator.Commands.ReservationCommands
{
    public class UpdateReservationStatusReceivedCommand : IRequest
    {
        public int Id { get; set; }
        public UpdateReservationStatusReceivedCommand(int id)
        {
            Id = id;
        }
    }
}
