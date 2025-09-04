using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Dto.CarPricingDtos
{
    public class ResultCarPricingListDto
    {
        public string Model { get; set; }
        public decimal DailyAmount { get; set; }
        public decimal WekklyAmount { get; set; }
        public decimal MonthlyAmount { get; set; }
        public string CoverImageUrl { get; set; }

    }
}
