using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CreditCar.Repository.Context
{
    public partial class creditcarContext : DbContext
    {
        public creditcarContext()
        {
        }

        public creditcarContext(DbContextOptions<creditcarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AsignarCliente> AsignarClientes { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Ejecutivo> Ejecutivos { get; set; } = null!;
        public virtual DbSet<MarcaVehiculo> MarcaVehiculos { get; set; } = null!;
        public virtual DbSet<Patio> Patios { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<SolicitudCredito> SolicitudCreditos { get; set; } = null!;
        public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=creditcar;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AsignarCliente>(entity =>
            {
                entity.HasKey(e => e.IdAsignarCliente);

                entity.ToTable("AsignarCliente");

                entity.Property(e => e.FechaAsignacion).HasColumnType("datetime");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.AsignarClientes)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AsignarCliente_Cliente");

                entity.HasOne(d => d.IdPatioNavigation)
                    .WithMany(p => p.AsignarClientes)
                    .HasForeignKey(d => d.IdPatio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AsignarCliente_Patio");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("Cliente");

                entity.Property(e => e.EstadoCivil)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdentificacionConyugue)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreConyugue)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SujetoCredito)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Persona");
            });

            modelBuilder.Entity<Ejecutivo>(entity =>
            {
                entity.HasKey(e => e.IdEjecutivo);

                entity.ToTable("Ejecutivo");

                entity.Property(e => e.Celular)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPatioNavigation)
                    .WithMany(p => p.Ejecutivos)
                    .HasForeignKey(d => d.IdPatio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ejecutivo_Patio");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Ejecutivos)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ejecutivo_Persona");
            });

            modelBuilder.Entity<MarcaVehiculo>(entity =>
            {
                entity.HasKey(e => e.IdMarcaVehiculo);

                entity.ToTable("MarcaVehiculo");

                entity.Property(e => e.Marca)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Patio>(entity =>
            {
                entity.HasKey(e => e.IdPatio);

                entity.ToTable("Patio");

                entity.Property(e => e.Direcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona);

                entity.ToTable("Persona");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SolicitudCredito>(entity =>
            {
                entity.HasKey(e => e.IdSolicitudCredito);

                entity.ToTable("SolicitudCredito");

                entity.Property(e => e.Estado)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaElaboracion).HasColumnType("datetime");

                entity.Property(e => e.Observacion).HasMaxLength(100);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.SolicitudCreditos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SolicitudCredito_Cliente");

                entity.HasOne(d => d.IdEjecutivoNavigation)
                    .WithMany(p => p.SolicitudCreditos)
                    .HasForeignKey(d => d.IdEjecutivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SolicitudCredito_Ejecutivo");

                entity.HasOne(d => d.IdPatioNavigation)
                    .WithMany(p => p.SolicitudCreditos)
                    .HasForeignKey(d => d.IdPatio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SolicitudCredito_Patio");

                entity.HasOne(d => d.IdVehiculoNavigation)
                    .WithMany(p => p.SolicitudCreditos)
                    .HasForeignKey(d => d.IdVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SolicitudCredito_Vehiculo");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.IdVehiculo);

                entity.ToTable("Vehiculo");

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Placa)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMarcaVehiculoNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.IdMarcaVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehiculo_MarcaVehiculo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
