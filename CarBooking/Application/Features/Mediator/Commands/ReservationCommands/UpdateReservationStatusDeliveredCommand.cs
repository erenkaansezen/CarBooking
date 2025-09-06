using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Mediator.Commands.ReservationCommands
{
    public class UpdateReservationStatusDeliveredCommand : IRequest
    {
        public int Id { get; set; }
        public UpdateReservationStatusDeliveredCommand(int id)
        {
            Id = id;
        }
    }
}
