using Npgsql;

namespace HostBooking
{
    public static class PostgresConn
    {
        public static NpgsqlConnection GetConn()
        {
            var conn =
                new NpgsqlConnection(
                    @"Server=ella.db.elephantsql.com; User Id=jmluhjvi; Password=IQ2k_i9cDXCvKo4daRFpu-jez5RjSriZ; Database=jmluhjvi");
            conn.Open();
            return conn;
        }
    }
}