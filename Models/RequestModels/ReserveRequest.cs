using System;

namespace HostBooking.Models.RequestModels
{
    public class ReserveRequest
    {
        public string TableId { get; set; }
        public string UserName { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
    }
}