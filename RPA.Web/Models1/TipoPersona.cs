using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RPA.Web.Models1;

[Table("TipoPersona")]
[Index("Descripcion", Name = "IX_TipoPersona_Descripcion", IsUnique = true)]
public partial class TipoPersona
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Descripcion { get; set; } = null!;

    [InverseProperty("TipoPersona")]
    public virtual ICollection<Persona> Personas { get; } = new List<Persona>();
}
