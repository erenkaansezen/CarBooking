using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Application.Interfaces.CarFeatureInterfaces
{
    public interface ICarFeatureRepository
    {
        List<CarFeature> GetCarFeaturesByIdCar(int carID);
        void ChangeCarFeatureAvailableToFalse(int id);
        void ChangeCarFeatureAvailableToTrue(int id);
    }
}
