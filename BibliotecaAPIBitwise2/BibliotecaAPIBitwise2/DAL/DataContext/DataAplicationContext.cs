using BibliotecaAPIBitwise2.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPIBitwise2.DAL.DataContext
{
    public class DataAplicationContext : DbContext
    {
        public DataAplicationContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genero>().Property(x => x.Nombre).HasMaxLength(100);

            modelBuilder.Entity<Autor>().Property(x => x.Nombre).HasMaxLength(100);
            modelBuilder.Entity<Autor>().Property(x => x.FechaNacimiento).HasColumnType("date");

            modelBuilder.Entity<Libro>().Property(x => x.Titulo).HasMaxLength(100);
            modelBuilder.Entity<Libro>().Property(x => x.FechaDeLanzamiento).HasColumnType("date");

            modelBuilder.Entity<Comentarios>().Property(x => x.Contenido).HasMaxLength(500);
        }

        public DbSet<Libro> Libros { get; set; }

        public DbSet<Autor> Autors { get; set; }

        public DbSet<Genero> Generos { get; set; }

        public DbSet<Comentarios> Comentarios { get; set; }
    }
}
