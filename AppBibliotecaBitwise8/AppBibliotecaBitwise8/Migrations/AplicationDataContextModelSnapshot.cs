﻿// <auto-generated />
using System;
using AppBibliotecaBitwise8.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppBibliotecaBitwise8.Migrations
{
    [DbContext(typeof(AplicationDataContext))]
    partial class AplicationDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppBibliotecaBitwise8.Models.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("autors");
                });

            modelBuilder.Entity("AppBibliotecaBitwise8.Models.Comentarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contenido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdLibro")
                        .HasColumnType("int");

                    b.Property<bool>("Recomendar")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdLibro");

                    b.ToTable("comentarios");
                });

            modelBuilder.Entity("AppBibliotecaBitwise8.Models.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("generos");
                });

            modelBuilder.Entity("AppBibliotecaBitwise8.Models.Libro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaPublic")
                        .HasColumnType("date");

                    b.Property<int>("IdAutor")
                        .HasColumnType("int");

                    b.Property<int>("IdGenero")
                        .HasColumnType("int");

                    b.Property<bool>("Recomendar")
                        .HasColumnType("bit");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdAutor");

                    b.HasIndex("IdGenero");

                    b.ToTable("libros");
                });

            modelBuilder.Entity("AppBibliotecaBitwise8.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("AppBibliotecaBitwise8.Models.Comentarios", b =>
                {
                    b.HasOne("AppBibliotecaBitwise8.Models.Libro", "Libros")
                        .WithMany("Comentarios")
                        .HasForeignKey("IdLibro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Libros");
                });

            modelBuilder.Entity("AppBibliotecaBitwise8.Models.Libro", b =>
                {
                    b.HasOne("AppBibliotecaBitwise8.Models.Autor", "Autor")
                        .WithMany("Libros")
                        .HasForeignKey("IdAutor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppBibliotecaBitwise8.Models.Genero", "Generos")
                        .WithMany("Libros")
                        .HasForeignKey("IdGenero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Generos");
                });

            modelBuilder.Entity("AppBibliotecaBitwise8.Models.Autor", b =>
                {
                    b.Navigation("Libros");
                });

            modelBuilder.Entity("AppBibliotecaBitwise8.Models.Genero", b =>
                {
                    b.Navigation("Libros");
                });

            modelBuilder.Entity("AppBibliotecaBitwise8.Models.Libro", b =>
                {
                    b.Navigation("Comentarios");
                });
#pragma warning restore 612, 618
        }
    }
}