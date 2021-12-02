using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostBooking.Models
{
    public class Entry : IDbEntity
    {
        public readonly int WhoTooked;
        public readonly int WhichTable;
        public readonly DateTime Time;
        public readonly int? Id;

        public Entry(int whoTooked, int whichTable, DateTime time, int? id = null)
        {
            WhoTooked = whoTooked;
            WhichTable = whichTable;
            Time = time;
            Id = id;
        }
    }
}