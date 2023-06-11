using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProyectoLavadero.Models
{
    public partial class DB_LAVADEROContext : DbContext
    {
        public DB_LAVADEROContext()
        {
        }

        public DB_LAVADEROContext(DbContextOptions<DB_LAVADEROContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HistorialLavado> HistorialLavados { get; set; } = null!;
        public virtual DbSet<TipoLavado> TipoLavados { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HistorialLavado>(entity =>
            {
                entity.HasKey(e => e.IdLavado)
                    .HasName("PK__Historia__955EEDC07717A4B8");

                entity.Property(e => e.FechaLavado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Matricula)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio");

                entity.HasOne(d => d.IdTipoLavadoNavigation)
                    .WithMany(p => p.HistorialLavados)
                    .HasForeignKey(d => d.IdTipoLavado)
                    .HasConstraintName("FK_HistorialLavados_TipoLavados");

                entity.HasOne(d => d.MatriculaNavigation)
                    .WithMany(p => p.HistorialLavados)
                    .HasForeignKey(d => d.Matricula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistorialLavados_Vehiculo1");
            });

            modelBuilder.Entity<TipoLavado>(entity =>
            {
                entity.HasKey(e => e.IdTipoLavado)
                    .HasName("PK__TipoLava__91A2D3E96FC79302");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97E78B6DE8");

                entity.ToTable("Usuario");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasenia)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.Matricula);

                entity.ToTable("Vehiculo");

                entity.Property(e => e.Matricula)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Marca)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Vehiculo_Usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
