using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Application.Interfaces.UserInterfaces
{
    public interface IAppUserRepository 
    {
        Task<List<AppUser>> GetByFilterAsync(Expression<Func<AppUser, bool>> filter);

    }
}
