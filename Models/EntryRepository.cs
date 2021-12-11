using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HostBooking.Models
{
    public class EntryRepository : IRepository
    {
        public void Insert(NpgsqlConnection dbCon, IDbEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(NpgsqlConnection dbCon, IDbEntity entity)
        {
            throw new NotImplementedException();
        }

        public static List<Entry> GetEntriesByIdTable(NpgsqlConnection dbCon, int idTable)
        // тут лучше возвращать не лист определенных энтрис а интерфейс Idbentity, но почему-то он 
        // не хочет кастить даже учитывая добавление связи в startup
        {
            using(AppContext db = new AppContext())
            {
                var enties = db.Entries.Where(a => a.WhichTable == idTable).ToList();
                return enties;
            }
        }

        public static List<Entry> GetEntriesByIdUser(NpgsqlConnection dbCon, int idUser)
        //тут соотв-но то же самое
        {
            using(AppContext db = new AppContext())
            {
                var entries = db.Entries.Where(a => a.WhoTooked == idUser).ToList();
                return entries;
            }
        }
    }
}