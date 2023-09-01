using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservationApp_1.Models
{
    public class RoomReservationContext : DbContext
    {
        public RoomReservationContext() : base("RoomContext") { }
        public DbSet<Rooms> Rooms { get; set; }
    }
}
