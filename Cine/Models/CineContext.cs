using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Cine.Models
{
    public partial class CineContext : DbContext
    {
        public CineContext()
        {
        }

        public CineContext(DbContextOptions<CineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pelicula> Peliculas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // Directiva #warning
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-HPNBML5R\\ALDANA; Database=Cine; Trusted_Connection=True;");
#pragma warning restore CS1030 // Directiva #warning
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.ToTable("Pelicula");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AñoPublicacion)
                    .HasColumnType("date")
                    .HasColumnName("Año_Publicacion");

                entity.Property(e => e.Director)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Rating)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
