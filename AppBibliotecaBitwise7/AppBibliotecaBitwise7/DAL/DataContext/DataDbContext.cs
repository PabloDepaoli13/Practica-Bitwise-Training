using AppBibliotecaBitwise7.Models;
using Microsoft.EntityFrameworkCore;

namespace AppBibliotecaBitwise7.DAL.DataContext
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Autor>().Property(e => e.Nombre).HasMaxLength(100);
            modelBuilder.Entity<Autor>().Property(e => e.FechaNac).HasColumnType("date");
            modelBuilder.Entity<Autor>().HasKey(e => e.Id);
            

            modelBuilder.Entity<Libro>().Property(e => e.Nombre).HasMaxLength(100);
            modelBuilder.Entity<Libro>().Property(e => e.FechaPublic).HasColumnType("date");
            modelBuilder.Entity<Libro>().HasKey(e => e.Id);
            modelBuilder.Entity<Libro>().HasOne(e => e.Autor).WithMany(a => a.Libros).HasForeignKey(a => a.IdAutor);
            modelBuilder.Entity<Libro>().HasOne(e => e.Genero).WithMany(a => a.Libros).HasForeignKey(a => a.IdGenero);

            modelBuilder.Entity<Comentario>().Property(e => e.Contenido).HasMaxLength(100);
            modelBuilder.Entity<Comentario>().HasKey(e => e.Id);

            modelBuilder.Entity<Genero>().Property(e => e.Nombre).HasMaxLength(100);
            modelBuilder.Entity<Genero>().HasKey(e => e.Id);
        }

        public DbSet<Libro> Libros { get; set; }

        public DbSet<Comentario > Comentarios { get; set; }

        public DbSet<Autor> Autores { get; set; }

        public DbSet<Genero> Generos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
