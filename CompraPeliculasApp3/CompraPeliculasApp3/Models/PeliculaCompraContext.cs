using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraPeliculasApp3.Models
{
    public class PeliculaCompraContext : DbContext
    {
        public DbSet<Pelicula> peliculas { get; set; }
    }
}
