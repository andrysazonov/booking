using System;
using System.Collections.Generic;
using System.Linq;

namespace HostBooking.Models.Repositories
{
    public class TableRepository : IRepository<Table>
    {
        public void Insert(Table entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Table entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<(string TableId, bool IsAvailable)> GetAllTablesWithStatus(DateTime timeFrom,
            DateTime timeTo)
        {
            using var db = new DbContext();
            var allTables = db.Tables.ToArray();
            foreach (var table in allTables)
                if (IsTableAvailable(timeFrom, timeTo, table, db))
                    yield return (table.Id, true);
                else
                    yield return (table.Id, false);
        }

        private bool IsTableAvailable(DateTime timeFrom, DateTime timeTo, Table table, DbContext db)
        {
            var tableReservations = db.Reservations.Where(r => r.TableId == table.Id);
            foreach (var reservation in tableReservations)
                if (AreReservationsIntersect(timeFrom.Ticks, timeTo.Ticks, reservation.TimeFrom.Ticks,
                    reservation.TimeTo.Ticks))
                    return false;

            return true;
        }

        public bool IsTableAvailable(DateTime timeFrom, DateTime timeTo, Table table)
        {
            using var db = new DbContext();
            var tableReservations = db.Reservations.Where(r => r.TableId == table.Id);
            foreach (var reservation in tableReservations)
                if (AreReservationsIntersect(timeFrom.Ticks, timeTo.Ticks, reservation.TimeFrom.Ticks,
                    reservation.TimeTo.Ticks))
                    return false;

            return true;
        }

        private static bool AreReservationsIntersect(long from1, long to1, long from2, long to2)
        {
            return IsInSegment(from2, from1, to1) || IsInSegment(to2, from1, to1)
                                                  || IsInSegment(from1, from2, to2) || IsInSegment(to1, from2, to2);
        }

        private static bool IsInSegment(long value, long segmentStart, long segmentEnd)
        {
            return value > segmentStart && value < segmentEnd;
        }
    }
}