using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Modelo;

namespace PruebaTecnica.Repositorio.DBContext;

public partial class PruebaTecnicaContext : DbContext
{
    public PruebaTecnicaContext()
    {
    }

    public PruebaTecnicaContext(DbContextOptions<PruebaTecnicaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Deporte> Deportes { get; set; }

    public virtual DbSet<Deportista> Deportista { get; set; }

    public virtual DbSet<Nacionalidad> Nacionalidads { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Deporte>(entity =>
        {
            entity.HasKey(e => e.IdDeporte).HasName("PK__Deporte__B5FFCC7D882409F1");

            entity.ToTable("Deporte");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Deportista>(entity =>
        {
            entity.HasKey(e => e.IdDeportista).HasName("PK__Deportis__9212E9410CDA7359");

            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Imagen).IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sexo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdDeporteNavigation).WithMany(p => p.Deportista)
                .HasForeignKey(d => d.IdDeporte)
                .HasConstraintName("FK__Deportist__IdDep__2B3F6F97");

            entity.HasOne(d => d.IdNacionalidadNavigation).WithMany(p => p.Deportista)
                .HasForeignKey(d => d.IdNacionalidad)
                .HasConstraintName("FK__Deportist__IdNac__2A4B4B5E");
        });

        modelBuilder.Entity<Nacionalidad>(entity =>
        {
            entity.HasKey(e => e.IdNacionalidad).HasName("PK__Nacional__021E36BEC0351DA5");

            entity.ToTable("Nacionalidad");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
