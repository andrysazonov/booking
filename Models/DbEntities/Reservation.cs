using System;
using HostBooking.Models;

#nullable disable

namespace HostBooking
{
    public class Reservation : IDbEntity
    {
        public string Id { get; set; }
        public string TableId { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public string UserName { get; set; }
    }
}