using AppBibliotecaBitwise3.Models;
using Microsoft.EntityFrameworkCore;

namespace AppBibliotecaBitwise3.DAL.DataContext
{
    public class DbAplicationContext : DbContext
    {
        public DbAplicationContext(DbContextOptions options) : base(options) 
        {

        }
        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);

            model.Entity<Autor>().Property(e => e.Nombre).HasMaxLength(100);
            model.Entity<Autor>().Property(e => e.FechaNacimiento).HasColumnType("date");

            model.Entity<Genero>().Property(e => e.Nombre).HasMaxLength(100);

            model.Entity<Comentario>().Property(e => e.Contenido).HasMaxLength(500);

            model.Entity<Libro>().Property(e => e.Titulo).HasMaxLength(150);
            model.Entity<Libro>().Property(e => e.FechaPublicacion).HasColumnType("date");
        }

        public DbSet<Libro> libros { get; set; }
        
        public DbSet<Genero> generos { get; set; }

        public DbSet<Comentario> comentarios { get; set; }  

        public DbSet<Autor> autores { get; set; }
    }
}
