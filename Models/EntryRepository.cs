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

        public List<IDbEntity> GetEntriesByIdTable(NpgsqlConnection dbCon, int idTable)
        {
            throw new NotImplementedException();
        }

        public List<IDbEntity> GetEntriesByIdUser(NpgsqlConnection dbCon, int idUser)
        {
            throw new NotImplementedException();
        }
    }
}