using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Mediator.Queries.ReviewQueries;
using Application.Features.Mediator.Results.PricingResults;
using Application.Features.Mediator.Results.ReviewResults;
using Application.Interfaces;
using Application.Interfaces.RewiewInterfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class GetReviewByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
    {
        private readonly IReviewRepository _reviewRepository;
        public GetReviewByCarIdQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values =_reviewRepository.GetReviewByCarId(request.Id);
            return values.Select(x => new GetReviewByCarIdQueryResult
            {
                ReviewID = x.ReviewID,
                CarId = x.CarId,
                Comment = x.Comment,
                CustomerImage = x.CustomerImage,
                CustomerName = x.CustomerName,
                RaytingValue = x.RaytingValue,
                ReviewDate = x.ReviewDate,
                
            }).ToList();
        }
    }
}
