using Application.Features.Mediator.Queries.StatisticQueries;
using Application.Features.Mediator.Results.StatisticResults;
using Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetCarCountByElectricQueryHandler : IRequestHandler<GetCarCountByElectricQuery, GetCarCountByElectricQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetCarCountByElectricQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }
        public async Task<GetCarCountByElectricQueryResult> Handle(GetCarCountByElectricQuery request, CancellationToken cancellationToken)
        {
            return new GetCarCountByElectricQueryResult
            {
                ElectricCarCount = _statisticsRepository.GetCarCountByElectric()
            };
        }
    }
}
