using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Mediator.Results.RentCarResults;
using MediatR;

namespace Application.Features.Mediator.Queries.RentCarQueries
{
    public class GetRentACarQuery : IRequest<List<GetRentACarQueryResult>>
    {
        public int LocationId { get; set; }
        public bool Avaible { get; set; }
    }
}
