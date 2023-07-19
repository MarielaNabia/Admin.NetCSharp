using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RPA.Web.Models1;

[Index("Nombre", "ProvinciaId", Name = "IX_Localidades_Nombre_ProvinciaId", IsUnique = true)]
public partial class Localidade
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    public int ProvinciaId { get; set; }

    [InverseProperty("Localidad")]
    public virtual ICollection<Domicilio> Domicilios { get; } = new List<Domicilio>();

    [ForeignKey("ProvinciaId")]
    [InverseProperty("Localidades")]
    public virtual Provincia Provincia { get; set; } = null!;
}
