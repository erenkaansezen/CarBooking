using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.CarPricingInterfaces;
using Application.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Web.Domain.Entities;
using Web.Persistence.Context;

namespace Web.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly WebContext _context;

        public CarPricingRepository(WebContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarPricingWithCars()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.Pricing).Where(a => a.PricingID == 2).ToList();
            return values;
        }
        public List<CarPricingViewModel> GetCarPricingWithTimePeriod1()
        {
            List<CarPricingViewModel> values = new List<CarPricingViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = @"
                                        SELECT
                                            Model,
                                            CoverImageUrl,
                                            CAST(ISNULL([1],0) AS decimal(18,2)) AS DailyAmount,
                                            CAST(ISNULL([2],0) AS decimal(18,2)) AS WeeklyAmount,
                                            CAST(ISNULL([3],0) AS decimal(18,2)) AS MonthlyAmount
                                        FROM (
                                            SELECT Model, CoverImageUrl, PricingID, Amount
                                            FROM CarPricings
                                            INNER JOIN Cars   ON Cars.CarID   = CarPricings.CarId
                                            INNER JOIN Brands ON Brands.BrandID = Cars.BrandID
                                        ) AS SourceTable
                                        PIVOT (
                                            SUM(Amount) FOR PricingID IN ([1],[2],[3])
                                        ) AS PivotTable;";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
                        {
                            Model = reader["Model"].ToString(),
                            CoverImageUrl = reader["CoverImageUrl"].ToString(),
                            Amounts = new List<decimal>
                            {
                                reader.GetDecimal(reader.GetOrdinal("DailyAmount")),
                                reader.GetDecimal(reader.GetOrdinal("WeeklyAmount")),
                                reader.GetDecimal(reader.GetOrdinal("MonthlyAmount"))
                            }

                        };
                        values.Add(carPricingViewModel);
                    }
                }
                _context.Database.CloseConnection();
                return values;
            }
        }
    }
}

        //public List<CarPricing> GetCarPricingWithTimePeriod()
        //{
        //    List<CarPricing> values = new List<CarPricing>();
        //    using(var command = _context.Database.GetDbConnection().CreateCommand())
        //    {
        //        	command.CommandText = "Select * From (Select Model,PricingID,Amount From CarPricings Inner Join Cars On Cars.CarID=CarPricings.CarId Inner Join Brands On Brands.BrandID=Cars.BrandID) As SourceTable Pivot (Sum(Amount) For PricingID In ([2],[3],[4])) as PivotTable;";
        //        	command.CommandType = System.Data.CommandType.Text;
        //        	_context.Database.OpenConnection();
        //        	using(var reader=command.ExecuteReader())
        //        	{
        //        		while (reader.Read())
        //        		{
        //        			CarPricing carPricing = new CarPricing();
        //        			Enumerable.Range(1, 3).ToList().ForEach(x =>
        //        			{
        //        				if (DBNull.Value.Equals(reader[x]))
        //        				{
        //                            CarPricing.
        //        				}
        //        				else
        //        				{
        //        					carPricing.Amount
        //        				}
        //        			});
        //        			values.Add(carPricing);
        //        		}
        //        	}
        //        	_context.Database.CloseConnection();
        //        	return values;	
        //    }
        //}
    
//var values = from x in _context.CarPricings
//             group x by x.CarID into g
//             select new
//             {
//                 CarId = g.Key,
//                 DailyPrice = g.Where(a => a.CarPricingID == 1).Sum(b => b.Amount),
//                 WeeklyPrice = g.Where(a => a.CarPricingID == 2).Sum(b => b.Amount),
//                 MonthlyPrice = g.Where(a => a.CarPricingID == 3).Sum(b => b.Amount),
//             };
//return values;