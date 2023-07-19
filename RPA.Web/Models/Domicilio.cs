using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RPA.Web;

public partial class Domicilio
{
    [Display( Name="Identificador")]
    public int Id { get; set; }

    public string Calle { get; set; } = null!;

    public int Altura { get; set; }

    public string? Torre { get; set; }

    public string? Piso { get; set; }

    public string? Departamento { get; set; }

    public string? Barrio { get; set; }

    [Display(Name = "Localidad")]
    public int LocalidadId { get; set; }

    [Display(Name = "Provincia")]
    public int ProvinciaId { get; set; }

    [Display(Name = "Código Postal")]
    public string? CodigoPostal { get; set; } 

    [Display(Name = "Consorcios Domicilios")]
    public virtual ICollection<ConsorcioDomicilio> ConsorciosDomicilios { get; } = new List<ConsorcioDomicilio>();

    public virtual Localidad Localidad { get; set; } = null!;

    [Display(Name = "Personas Domicilios")]
    public virtual ICollection<PersonaDomicilio> PersonasDomicilios { get; } = new List<PersonaDomicilio>();

    public virtual Provincia Provincia { get; set; } = null!;
}
