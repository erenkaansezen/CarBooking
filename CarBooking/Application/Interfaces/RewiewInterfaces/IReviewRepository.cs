using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Application.Interfaces.RewiewInterfaces
{
    public interface IReviewRepository
    {
        public List<Review> GetReviewByCarId(int id);
    }
}
