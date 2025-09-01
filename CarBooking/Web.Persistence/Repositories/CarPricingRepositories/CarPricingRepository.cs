using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.CarPricingInterfaces;
using Microsoft.EntityFrameworkCore;
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
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.Pricing).Where(a=> a.PricingID==2).ToList();
            return values;
        }
    }
}
