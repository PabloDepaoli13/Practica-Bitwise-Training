

using AppBibliotecaBitwise5.Models;
using Microsoft.EntityFrameworkCore;

namespace AppBibliotecaBitwise5.DAL.DataContext
{
    public class AplicationContext :  DbContext
    {
        public AplicationContext(DbContextOptions option) : base(option) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Autor>().Property(e => e.FechaNacimiento).HasColumnType("date");

            modelBuilder.Entity<Libro>().Property(e => e.FechaPublicacion).HasColumnType("date");
        }





        public DbSet<Libro> Libro { get; set; }
        public DbSet<Comentarios> Comentarios { get; set; }

        public DbSet<Genero> Generos { get; set; }

        public DbSet<Autor> Autor { get; set; }
     }
}
