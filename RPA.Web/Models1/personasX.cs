using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RPA.Web.Models1;

[Keyless]
[Table("personasX")]
public partial class personasX
{
    public int Id { get; set; }

    public int TipoPersonaId { get; set; }

    [StringLength(13)]
    [Unicode(false)]
    public string CuitCuil { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string? RazonSocial { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Apellido { get; set; }

    public int? TipoDocumentoId { get; set; }

    public int? NumeroDocumento { get; set; }

    public int? GeneroId { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaNacimiento { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Telefono1 { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Telefono2 { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Celular1 { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Celular2 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Email1 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Email2 { get; set; }
}
