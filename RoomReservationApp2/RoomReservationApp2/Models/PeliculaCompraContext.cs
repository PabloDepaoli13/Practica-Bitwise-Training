using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservationApp2.Models
{
    public class PeliculaCompraContext : DbContext
    {
        public DbSet<Peliculas> Peliculas { get; set; }
    }
}
