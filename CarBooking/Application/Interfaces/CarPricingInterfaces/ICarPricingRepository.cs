﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Application.Interfaces.CarPricingInterfaces
{
    public interface ICarPricingRepository 
    {
        List<CarPricing> GetCarPricingWithCars();

    }
}
