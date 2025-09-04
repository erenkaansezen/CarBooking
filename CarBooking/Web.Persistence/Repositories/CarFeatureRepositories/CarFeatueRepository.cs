using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.CarFeatureInterfaces;
using Microsoft.EntityFrameworkCore;
using Web.Domain.Entities;
using Web.Persistence.Context;

namespace Web.Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatueRepository : ICarFeatureRepository
    {
        private readonly WebContext _context;

        public CarFeatueRepository(WebContext context)
        {
            _context = context;
        }

        public void ChangeCarFeatureAvailableToFalse(int id)
        {
            var values = _context.CarFeatures.Find(id);
            values.Available = false;
            _context.SaveChanges();
        }

        public void ChangeCarFeatureAvailableToTrue(int id)
        {
            var values = _context.CarFeatures.Find(id);
            values.Available = true;
            _context.SaveChanges();
        }

        public List<CarFeature> GetCarFeaturesByIdCar(int carID)
        {
            var values = _context.CarFeatures.Include(y=>y.Feature).Where(x => x.CarID == carID).ToList();
            return values;
        }
    }
}
