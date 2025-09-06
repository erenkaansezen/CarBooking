using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.RewiewInterfaces;
using Web.Domain.Entities;
using Web.Persistence.Context;

namespace Web.Persistence.Repositories.RewiewRepositories
{
    public class RewiewRepository : IReviewRepository
    {
        private readonly WebContext _context;
        public RewiewRepository(WebContext context)
        {
            _context = context;
        }
        public List<Review> GetReviewByCarId(int id)
        {
            var values = _context.Reviews.Where(x => x.CarId == id).ToList();
            return values;
        }
    }
}
