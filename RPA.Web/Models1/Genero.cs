using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RPA.Web.Models1;

[Table("Genero")]
[Index("Codigo", Name = "IX_Genero_Codigo", IsUnique = true)]
[Index("Descripcion", Name = "IX_Genero_Descripcion", IsUnique = true)]
public partial class Genero
{
    [Key]
    public int Id { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string Codigo { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string Descripcion { get; set; } = null!;

    [InverseProperty("Genero")]
    public virtual ICollection<Persona> Personas { get; } = new List<Persona>();
}
