using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.CarInterfaces;
using Microsoft.EntityFrameworkCore;
using Web.Domain.Entities;
using Web.Persistence.Context;

namespace Web.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly WebContext _context = new WebContext();

        public CarRepository(WebContext context)
        {
            _context = context;
        }
        public List<Car> GetCarsListWithBrand()
        {
            var values = _context.Cars.Include(x => x.Brand).ToList();
            return values;
        }
    }
}
