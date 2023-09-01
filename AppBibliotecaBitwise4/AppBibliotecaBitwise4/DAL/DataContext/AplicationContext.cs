using AppBibliotecaBitwise4.Models;
using Microsoft.EntityFrameworkCore;

namespace AppBibliotecaBitwise4.DAL.DataContext
{
    public class AplicationContext : DbContext
    {
        public AplicationContext(DbContextOptions options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Autor>().Property(e => e.Nombre).HasMaxLength(100);
            modelBuilder.Entity<Autor>().Property(e => e.FechaNacimiento).HasColumnType("date");

            modelBuilder.Entity<Libro>().Property(e => e.Titulo).HasMaxLength(100);
            modelBuilder.Entity<Libro>().Property(e => e.FechaPublicacion).HasColumnType("date");

            modelBuilder.Entity<Genero>().Property(e => e.Nombre).HasMaxLength(100);

            modelBuilder.Entity<Comentario>().Property(e => e.Contenido).HasMaxLength(600);

        }


        public DbSet<Autor> autors { get; set; }

        public DbSet<Comentario> comentarios { get; set; }

        public DbSet<Genero> generos { get; set; }

        public DbSet<Libro> libros { get; set; }
    }
}
