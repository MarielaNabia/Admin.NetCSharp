using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RPA.Web.Models1;

[Index("Nombre", Name = "IX_Provincias_Nombres", IsUnique = true)]
public partial class Provincia
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("Provincia")]
    public virtual ICollection<Domicilio> Domicilios { get; } = new List<Domicilio>();

    [InverseProperty("Provincia")]
    public virtual ICollection<Localidade> Localidades { get; } = new List<Localidade>();
}
