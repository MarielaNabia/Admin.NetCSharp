using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RPA.Web.Models1;

namespace RPA.Web.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administradore> Administradores { get; set; }

    public virtual DbSet<Consorcio> Consorcios { get; set; }

    public virtual DbSet<ConsorciosAdministradore> ConsorciosAdministradores { get; set; }

    public virtual DbSet<ConsorciosDomicilio> ConsorciosDomicilios { get; set; }

    public virtual DbSet<Domicilio> Domicilios { get; set; }

    public virtual DbSet<EstadoMatricula> EstadoMatriculas { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Localidade> Localidades { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<PersonasDomicilio> PersonasDomicilios { get; set; }

    public virtual DbSet<PersonasTemp> PersonasTemps { get; set; }

    public virtual DbSet<Provincia> Provincias { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<TipoDomicilio> TipoDomicilios { get; set; }

    public virtual DbSet<TipoPersona> TipoPersonas { get; set; }

    public virtual DbSet<personasX> personasXes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=SQL5109.site4now.net;Initial Catalog=db_a91b98_rpa;User Id=db_a91b98_rpa_admin;Password=pwdPIL01SQL;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AI");

        modelBuilder.Entity<Administradore>(entity =>
        {
            entity.HasOne(d => d.EstadoMatricula).WithMany(p => p.Administradores)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Administradores_EstadoMatricula");

            entity.HasOne(d => d.Persona).WithMany(p => p.Administradores)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Administradores_Personas");
        });

        modelBuilder.Entity<Consorcio>(entity =>
        {
            entity.Property(e => e.Cuit).IsFixedLength();
        });

        modelBuilder.Entity<ConsorciosAdministradore>(entity =>
        {
            entity.HasOne(d => d.Administrador).WithMany(p => p.ConsorciosAdministradores)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConsorciosAdministradores_Administradores");

            entity.HasOne(d => d.Consorcio).WithMany(p => p.ConsorciosAdministradores)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConsorciosAdministradores_Consorcios");
        });

        modelBuilder.Entity<ConsorciosDomicilio>(entity =>
        {
            entity.HasOne(d => d.Consorcio).WithMany(p => p.ConsorciosDomicilios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConsorciosDomicilios_Consorcios");

            entity.HasOne(d => d.Domicilio).WithMany(p => p.ConsorciosDomicilios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConsorciosDomicilios_Domicilios");

            entity.HasOne(d => d.TipoDomicilio).WithMany(p => p.ConsorciosDomicilios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConsorciosDomicilios_TipoDomicilio");
        });

        modelBuilder.Entity<Domicilio>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Localidad).WithMany(p => p.Domicilios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Domicilios_Localidades");

            entity.HasOne(d => d.Provincia).WithMany(p => p.Domicilios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Domicilios_Provincias");
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.Property(e => e.Codigo).IsFixedLength();
        });

        modelBuilder.Entity<Localidade>(entity =>
        {
            entity.HasOne(d => d.Provincia).WithMany(p => p.Localidades)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Localidades_Provincias");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.Property(e => e.CuitCuil).IsFixedLength();

            entity.HasOne(d => d.Genero).WithMany(p => p.Personas).HasConstraintName("FK_Personas_Genero");

            entity.HasOne(d => d.TipoDocumento).WithMany(p => p.Personas).HasConstraintName("FK_Personas_TipoDocumento");

            entity.HasOne(d => d.TipoPersona).WithMany(p => p.Personas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Personas_TiposPersona");
        });

        modelBuilder.Entity<PersonasDomicilio>(entity =>
        {
            entity.HasOne(d => d.Domicilio).WithMany(p => p.PersonasDomicilios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonasDomicilios_Domicilios");

            entity.HasOne(d => d.Persona).WithMany(p => p.PersonasDomicilios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonasDomicilios_Personas");

            entity.HasOne(d => d.TipoDomicilio).WithMany(p => p.PersonasDomicilios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonasDomicilios_TipoDomicilio");
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.Property(e => e.Codigo).IsFixedLength();
        });

        modelBuilder.Entity<personasX>(entity =>
        {
            entity.Property(e => e.CuitCuil).IsFixedLength();
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
