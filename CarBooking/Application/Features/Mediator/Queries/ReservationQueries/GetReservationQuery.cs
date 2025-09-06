using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Mediator.Results.ReservationResults;
using MediatR;

namespace Application.Features.Mediator.Queries.ReservationQueries
{
    public class GetReservationQuery : IRequest<List<GetReservationQueryResult>>
    {
    }
}
