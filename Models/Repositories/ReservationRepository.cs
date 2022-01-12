using System;
using System.Collections.Generic;
using System.Linq;

namespace HostBooking.Models.Repositories
{
    public class ReservationRepository : IRepository<Reservation>
    {
        public void Insert(Reservation entity)
        {
            using var db = new DbContext();
            db.Add(entity);
            db.SaveChanges();
        }

        public void Update(Reservation entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> GetUserReservations(string userName)
        {
            using var db = new DbContext();
            return db.Reservations.Where(r => r.UserName == userName);
        }

        public void Delete(string id, string userName)
        {
            using var db = new DbContext();
            var reservation = db.Reservations.Where(r => r.Id == id && r.UserName == userName);
            if (!reservation.Any())
                return;
            db.Reservations.Remove(reservation.First());
            db.SaveChanges();
        }
    }
}