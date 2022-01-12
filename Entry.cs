using System;

#nullable disable

namespace HostBooking
{
    public class Entry
    {
        public int IdEntry { get; set; }
        public int? WhoTooked { get; set; }
        public int? WhichTable { get; set; }
        public DateTime? RecordTime { get; set; }
    }
}