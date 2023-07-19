using System;
using System.Collections.Generic;

namespace RPA.Domain.Entities;

public partial class Domicilio
{
    public int Id { get; set; }

    public string Calle { get; set; } = null!;

    public int Altura { get; set; }

    public string? Torre { get; set; }

    public string? Piso { get; set; }

    public string? Departamento { get; set; }

    public string? Barrio { get; set; }

    public int LocalidadId { get; set; }

    public int ProvinciaId { get; set; }

    public string CodigoPostal { get; set; } = null!;

    public virtual ICollection<ConsorcioDomicilio> ConsorciosDomicilios { get; } = new List<ConsorcioDomicilio>();

    public virtual Localidad Localidad { get; set; } = null!;

    public virtual ICollection<PersonaDomicilio> PersonasDomicilios { get; } = new List<PersonaDomicilio>();

    public virtual Provincia Provincia { get; set; } = null!;
}
