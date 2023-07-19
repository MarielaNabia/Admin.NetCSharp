using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RPA.Web.Models1;

[Index("Cuit", Name = "IX_Consorcios_Cuit", IsUnique = true)]
public partial class Consorcio
{
    [Key]
    public int Id { get; set; }

    [StringLength(13)]
    [Unicode(false)]
    public string Cuit { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string Denominacion { get; set; } = null!;

    [Column(TypeName = "date")]
    public DateTime FechaAlta { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaBaja { get; set; }

    [InverseProperty("Consorcio")]
    public virtual ICollection<ConsorciosAdministradore> ConsorciosAdministradores { get; } = new List<ConsorciosAdministradore>();

    [InverseProperty("Consorcio")]
    public virtual ICollection<ConsorciosDomicilio> ConsorciosDomicilios { get; } = new List<ConsorciosDomicilio>();
}
