using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Dto.StatisticDtos
{
    public class ResultStatisticsDto
    {
        public int CarCount { get; set; }
        public string BrandNameByMaxCar { get; set; }
        public decimal AvgDailyPrice { get; set; }
        public decimal AvgWeeklyPrice { get; set; }
        public decimal AvgMonthlyPrice { get; set; }
        public int BrandCount { get; set; }
        public int ElectricCarCount { get; set; }
        public int CarCountByTransmissionIsAuto { get; set; }

        public int LocationCount { get; set; }
    }
}
