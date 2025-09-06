using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.ReservationInterfaces;
using Web.Persistence.Context;

namespace Web.Persistence.Repositories.ReservationRepositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly WebContext _context;

        public ReservationRepository(WebContext context)
        {
            _context = context;
        }

        public void UpdateReservationStatusToDelivered(int id)
        {
            var values = _context.Reservations.Find(id);
            values.Status = "Teslim Edildi";
            _context.SaveChanges();
        }

        public void UpdateReservationStatusToReceived(int id)
        {
            var values = _context.Reservations.Find(id);
            values.Status = "Teslim Alındı";
            _context.SaveChanges();
        }
    }
}
