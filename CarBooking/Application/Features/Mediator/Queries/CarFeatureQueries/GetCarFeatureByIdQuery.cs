using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Mediator.Results.CarFeatureResults;
using Application.Features.Mediator.Results.LocationResults;
using MediatR;

namespace Application.Features.Mediator.Queries.CarFeatureQueries
{
    public class GetCarFeatureByIdQuery : IRequest<List<GetCarFeatureByIdQueryResult>>
    {
        public int Id { get; set; }
        public GetCarFeatureByIdQuery(int id)
        {
            Id = id;
        }
    }
}
