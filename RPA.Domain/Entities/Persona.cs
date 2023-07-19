using System;
using System.Collections.Generic;

namespace RPA.Domain.Entities;

public partial class Persona
{
    public int Id { get; set; }

    public int TipoPersonaId { get; set; }

    public int CuitCuil { get; set; }

    public string Nombre { get; set; } 

    public string Apellido { get; set; } 

    public int TipoDocumentoId { get; set; }

    public virtual TipoDocumento TipoDocumento { get; set; }

    public int NumeroDocumento { get; set; }

    public int GeneroId { get; set; }

    public virtual Genero Genero { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string RazonSocial { get; set; } 

    public string? Telefono1 { get; set; }

    public string? Telefono2 { get; set; }

    public string? Celular1 { get; set; }

    public string? Celular2 { get; set; }

    public string? Email1 { get; set; }

    public string? Email2 { get; set; }

    public virtual ICollection<Administrador> Administradores { get; } = new List<Administrador>();

    public virtual ICollection<PersonaDomicilio> PersonasDomicilios { get; } = new List<PersonaDomicilio>();


    public virtual TipoPersona TipoPersona { get; set; } = null!;
}