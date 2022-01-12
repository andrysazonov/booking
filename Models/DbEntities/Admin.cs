using HostBooking.Models;

#nullable disable

namespace HostBooking
{
    public class Admin : IDbEntity
    {
        public int Idadmin { get; set; }
        public string AdminSurname { get; set; }
        public string Adminname { get; set; }
        public string Adminsecondname { get; set; }
        public string Adminlogin { get; set; }
        public string Adminpassword { get; set; }
    }
}