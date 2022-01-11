using Npgsql;

namespace HostBooking.Models
{
    internal interface IRepository
    {
        public void Insert(NpgsqlConnection dbCon, IDbEntity entity);
        public void Update(NpgsqlConnection dbCon, IDbEntity entity);
    }
}