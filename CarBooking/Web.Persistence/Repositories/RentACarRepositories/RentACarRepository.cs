using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.RentACarInterfaces;
using Microsoft.EntityFrameworkCore;
using Web.Domain.Entities;
using Web.Persistence.Context;

namespace Web.Persistence.Repositories.RentACarRepositories
{
    public class RentACarRepository : IRentACarRepository
    {
        private readonly WebContext _context;

        public RentACarRepository(WebContext context)
        {
            _context = context;
        }

        public async Task<List<RentACar>> GetByFilterAsync(Expression<Func<RentACar, bool>> filter)
        {
            var values =await _context.RentACars.Where(filter).Include(x=>x.Car).ThenInclude(x => x.Brand).Include(x => x.Location).ToListAsync();
            return values.ToList();
        }
    }
}
