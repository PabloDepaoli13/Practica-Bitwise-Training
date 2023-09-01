using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMovieApp.Models
{
    public class PeliculasDBContext : DbContext
    {
        public DbSet<Peliculas> peliculas { get; set;}
    }
}
