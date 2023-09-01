

using AppBibliotecaBitwise6.Models;
using Microsoft.EntityFrameworkCore;

namespace AppBibliotecaBitwise6.DAL.DataContext
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
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

            modelBuilder.Entity<Usuario>().Property(e => e.Nombre).HasMaxLength(100);

            modelBuilder.Entity<Comentario>().Property(e => e.Contenido).HasMaxLength(500);
        }

        public DbSet<Autor> Autores { get; set; }
        
        public DbSet<Comentario> Comentarios { get; set; }

        public DbSet<Genero> Generos { get; set; }

        public DbSet<Libro> Libros { get; set; } 

        public DbSet<Usuario> Usuarios { get; set; }    
    }
}
