using AppBibliotecaBitwise8.Models;
using Microsoft.EntityFrameworkCore;

namespace AppBibliotecaBitwise8.DAL.DataContext
{
    public class AplicationDataContext : DbContext
    {
        public AplicationDataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Autor>().HasKey(e => e.Id);
            
            modelBuilder.Entity<Libro>().HasKey(e => e.Id);
            modelBuilder.Entity<Comentarios>().HasKey(e => e.Id);
            modelBuilder.Entity<Genero>().HasKey(e => e.Id);

            modelBuilder.Entity<Libro>().HasOne(e => e.Autor).WithMany(a => a.Libros).HasForeignKey(a => a.IdAutor);
            modelBuilder.Entity<Libro>().HasOne(e => e.Generos).WithMany(a => a.Libros).HasForeignKey(a => a.IdGenero);

            modelBuilder.Entity<Autor>().Property(e => e.FechaNacimiento).HasColumnType("date");

            modelBuilder.Entity<Libro>().Property(e => e.FechaPublic).HasColumnType("date");
        }


        public DbSet<Libro> libros { get; set; }

        public DbSet<Comentarios> comentarios { get; set; }
        
        public DbSet<Genero> generos { get; set; }  

        public DbSet<Autor> autors { get; set; }

        public DbSet<Usuario> usuarios { get; set; }
    }
}
