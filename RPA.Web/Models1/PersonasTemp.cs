using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RPA.Web.Models1;

[Keyless]
[Table("PersonasTemp")]
public partial class PersonasTemp
{
    public double? PersonaId { get; set; }

    public double? TipoPersonaId { get; set; }

    [StringLength(255)]
    public string? Nombre { get; set; }

    [StringLength(255)]
    public string? Apellido { get; set; }

    [StringLength(255)]
    public string? RazonSocial { get; set; }

    [StringLength(255)]
    public string? TipoDocumentoId { get; set; }

    [StringLength(255)]
    public string? NroDocumento { get; set; }

    [StringLength(255)]
    public string? Sexo { get; set; }

    [StringLength(255)]
    public string? NroDocumento2 { get; set; }

    [StringLength(255)]
    public string? CorreoElectronico { get; set; }

    [StringLength(255)]
    public string? CorreoElectronico1 { get; set; }

    public double? Telefono { get; set; }

    [StringLength(255)]
    public string? Celular { get; set; }

    public double? Cuit { get; set; }
}
