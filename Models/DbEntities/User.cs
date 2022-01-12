using HostBooking.Models;

#nullable disable

namespace HostBooking
{
    public class User : IDbEntity
    {
        public string UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
    }
}