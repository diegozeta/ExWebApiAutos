using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApiAutos.Model.AutosDB
{
    public partial class AutosDbContext : DbContext
    {
        public AutosDbContext()
        {
        }

        public AutosDbContext(DbContextOptions<AutosDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autos> Autos { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source = WIN-PORTABLE; initial catalog = AutosDB; Trusted_Connection = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autos>(entity =>
            {
                entity.HasKey(e => e.IdAutos);

                entity.Property(e => e.IdAutos)
                    .HasColumnName("id_autos")
                    .ValueGeneratedNever();

                entity.Property(e => e.AñoFab)
                    .HasColumnName("año_fab")
                    .HasColumnType("datetime");

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Esfull)
                    .IsRequired()
                    .HasColumnName("esfull")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Esmecanico)
                    .IsRequired()
                    .HasColumnName("esmecanico")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdMarca).HasColumnName("id_marca");

                entity.Property(e => e.NroAsientos).HasColumnName("nro_asientos");

                entity.Property(e => e.NroPlaca)
                    .IsRequired()
                    .HasColumnName("nro_placa")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Autos)
                    .HasForeignKey(d => d.IdMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Autos__id_marca__4BAC3F29");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca);

                entity.Property(e => e.IdMarca)
                    .HasColumnName("id_marca")
                    .ValueGeneratedNever();

                entity.Property(e => e.NombreMarca)
                    .HasColumnName("nombre_marca")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
