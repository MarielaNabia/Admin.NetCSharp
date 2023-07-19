using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RPA.Web;

public partial class RPADBContext : DbContext
{
    public RPADBContext()
    {
    }

    public RPADBContext(DbContextOptions<RPADBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrador> Administradores { get; set; }

    public virtual DbSet<Consorcio> Consorcios { get; set; }

    public virtual DbSet<ConsorcioAdministrador> ConsorciosAdministradores { get; set; }

    public virtual DbSet<ConsorcioDomicilio> ConsorciosDomicilios { get; set; }

    public virtual DbSet<Domicilio> Domicilios { get; set; }

    public virtual DbSet<EstadoMatricula> EstadoMatriculas { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Localidad> Localidades { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<PersonaDomicilio> PersonasDomicilios { get; set; }


    public virtual DbSet<Provincia> Provincias { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<TipoDomicilio> TipoDomicilios { get; set; }

    public virtual DbSet<TipoPersona> TipoPersonas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=RPADB;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasIndex(e => e.Matricula, "IX_Administradores_Matricula").IsUnique();

            entity.Property(e => e.FechaActualizacion).HasColumnType("date");
            entity.Property(e => e.FechaAlta).HasColumnType("date");
            entity.Property(e => e.FechaBaja).HasColumnType("date");
            entity.Property(e => e.FechaSuspension).HasColumnType("date");
            entity.Property(e => e.Observaciones).HasColumnType("text");

            entity.HasOne(d => d.EstadoMatricula).WithMany(p => p.Administradores)
                .HasForeignKey(d => d.EstadoMatriculaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Administradores_EstadoMatricula");

            entity.HasOne(d => d.Persona).WithMany(p => p.Administradores)
                .HasForeignKey(d => d.PersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Administradores_Personas");
        });

        modelBuilder.Entity<Consorcio>(entity =>
        {
            entity.HasIndex(e => e.Cuit, "IX_Consorcios_Cuit").IsUnique();

            entity.Property(e => e.Denominacion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FechaAlta).HasColumnType("date");
            entity.Property(e => e.FechaBaja).HasColumnType("date");
        });

        modelBuilder.Entity<ConsorcioAdministrador>(entity =>
        {
            entity.Property(e => e.FechaAlta).HasColumnType("date");
            entity.Property(e => e.FechaBaja).HasColumnType("date");

            entity.HasOne(d => d.Administrador).WithMany(p => p.ConsorciosAdministradores)
                .HasForeignKey(d => d.AdministradorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConsorciosAdministradores_Administradores");

            entity.HasOne(d => d.Consorcio).WithMany(p => p.ConsorciosAdministradores)
                .HasForeignKey(d => d.ConsorcioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConsorciosAdministradores_Consorcios");
        });

        modelBuilder.Entity<ConsorcioDomicilio>(entity =>
        {
            entity.Property(e => e.FechaAlta).HasColumnType("date");
            entity.Property(e => e.FechaBaja).HasColumnType("date");

            entity.HasOne(d => d.Consorcio).WithMany(p => p.ConsorciosDomicilios)
                .HasForeignKey(d => d.ConsorcioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConsorciosDomicilios_Consorcios");

            entity.HasOne(d => d.Domicilio).WithMany(p => p.ConsorciosDomicilios)
                .HasForeignKey(d => d.DomicilioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConsorciosDomicilios_Domicilios");

            entity.HasOne(d => d.TipoDomicilio).WithMany(p => p.ConsorciosDomicilios)
                .HasForeignKey(d => d.TipoDomicilioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConsorciosDomicilios_TipoDomicilio");
        });

        modelBuilder.Entity<Domicilio>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Barrio)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Calle)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Departamento)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Piso)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Torre)
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.HasOne(d => d.Localidad).WithMany(p => p.Domicilios)
                .HasForeignKey(d => d.LocalidadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Domicilios_Localidades");

            entity.HasOne(d => d.Provincia).WithMany(p => p.Domicilios)
                .HasForeignKey(d => d.ProvinciaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Domicilios_Provincias");
        });

        modelBuilder.Entity<EstadoMatricula>(entity =>
        {
            entity.ToTable("EstadoMatricula");

            entity.HasIndex(e => e.Descripcion, "IX_EstadoMatricula_Descripcion").IsUnique();

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.ToTable("Genero");

            entity.HasIndex(e => e.Codigo, "IX_Genero_Codigo").IsUnique();

            entity.HasIndex(e => e.Descripcion, "IX_Genero_Descripcion").IsUnique();

            entity.Property(e => e.Codigo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Localidad>(entity =>
        {
            entity.HasIndex(e => new { e.Nombre, e.ProvinciaId }, "IX_Localidades_Nombre_ProvinciaId").IsUnique();

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Provincia).WithMany(p => p.Localidades)
                .HasForeignKey(d => d.ProvinciaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Localidades_Provincias");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasIndex(e => e.CuitCuil, "IX_Personas_CuitCuil").IsUnique();

            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            


            entity.Property(e => e.RazonSocial)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.Celular1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Celular2)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Email1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Telefono2)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.TipoPersona).WithMany(p => p.Personas)
                .HasForeignKey(d => d.TipoPersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Personas_TiposPersona");

            entity.HasOne(d => d.Genero).WithMany(p => p.Personas)
                .HasForeignKey(d => d.GeneroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Personas_Genero");



            entity.HasOne(d => d.TipoDocumento).WithMany(p => p.Personas)
                .HasForeignKey(d => d.TipoDocumentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Personas_TipoDocumento");
        });

        modelBuilder.Entity<PersonaDomicilio>(entity =>
        {
            entity.Property(e => e.FechaAlta).HasColumnType("date");
            entity.Property(e => e.FechaBaja).HasColumnType("date");

            entity.HasOne(d => d.Domicilio).WithMany(p => p.PersonasDomicilios)
                .HasForeignKey(d => d.DomicilioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonasDomicilios_Domicilios");

            entity.HasOne(d => d.Persona).WithMany(p => p.PersonasDomicilios)
                .HasForeignKey(d => d.PersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonasDomicilios_Personas");

            entity.HasOne(d => d.TipoDomicilio).WithMany(p => p.PersonasDomicilios)
                .HasForeignKey(d => d.TipoDomicilioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonasDomicilios_TipoDomicilio");
        });


        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasIndex(e => e.Nombre, "IX_Provincias_Nombres").IsUnique();

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.ToTable("TipoDocumento");

            entity.HasIndex(e => e.Codigo, "IX_TipoDocumento_Codigo").IsUnique();

            entity.HasIndex(e => e.Descripcion, "IX_TipoDocumento_Descripcion").IsUnique();

            entity.Property(e => e.Codigo)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoDomicilio>(entity =>
        {
            entity.ToTable("TipoDomicilio");

            entity.HasIndex(e => e.Descripcion, "IX_TipoDomicilio_Descripcion").IsUnique();

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoPersona>(entity =>
        {
            entity.ToTable("TipoPersona");

            entity.HasIndex(e => e.Descripcion, "IX_TipoPersona_Descripcion").IsUnique();

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
