using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.UserInterfaces;
using Microsoft.EntityFrameworkCore;
using Web.Domain.Entities;
using Web.Persistence.Context;

namespace Web.Persistence.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {   private readonly WebContext _context;

        public AppUserRepository(WebContext context)
        {
            _context = context;
        }

        public async Task<List<AppUser>> GetByFilterAsync(Expression<Func<AppUser, bool>> filter)
        {
            var values = await _context.AppUsers.Where(filter).ToListAsync();
            return values.ToList();
        }
    }
}
