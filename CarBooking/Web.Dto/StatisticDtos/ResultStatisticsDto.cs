using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Dto.StatisticDtos
{
    public class ResultStatisticsDto
    {
        public int carCount { get; set; }
        public string brandNameByMaxCar { get; set; }
        public decimal avgDailyPrice { get; set; }
        public decimal avgWeeklyPrice { get; set; }
        public decimal avgMonthlyPrice { get; set; }
        public int brandCount { get; set; }
        public int electricCarCount { get; set; }
        public int carCountByTransmissionIsAuto { get; set; }

        public int locationCount { get; set; }
    }
}
