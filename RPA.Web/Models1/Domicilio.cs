using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RPA.Web.Models1;

public partial class Domicilio
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string Calle { get; set; } = null!;

    public int Altura { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string? Torre { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string? Piso { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string? Departamento { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Barrio { get; set; }

    public int LocalidadId { get; set; }

    public int ProvinciaId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string CodigoPostal { get; set; } = null!;

    [InverseProperty("Domicilio")]
    public virtual ICollection<ConsorciosDomicilio> ConsorciosDomicilios { get; } = new List<ConsorciosDomicilio>();

    [ForeignKey("LocalidadId")]
    [InverseProperty("Domicilios")]
    public virtual Localidade Localidad { get; set; } = null!;

    [InverseProperty("Domicilio")]
    public virtual ICollection<PersonasDomicilio> PersonasDomicilios { get; } = new List<PersonasDomicilio>();

    [ForeignKey("ProvinciaId")]
    [InverseProperty("Domicilios")]
    public virtual Provincia Provincia { get; set; } = null!;
}
