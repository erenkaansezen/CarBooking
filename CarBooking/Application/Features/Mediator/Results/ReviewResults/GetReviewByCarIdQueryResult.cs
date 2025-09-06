using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Application.Features.Mediator.Results.ReviewResults
{
    public class GetReviewByCarIdQueryResult
    {
        public int ReviewID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerImage { get; set; }
        public string RaytingValue { get; set; }
        public DateTime ReviewDate { get; set; }
        public int CarId { get; set; }
        public string Comment { get; set; }
    }
}
