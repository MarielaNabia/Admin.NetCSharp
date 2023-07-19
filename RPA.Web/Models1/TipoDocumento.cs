using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RPA.Web.Models1;

[Table("TipoDocumento")]
[Index("Codigo", Name = "IX_TipoDocumento_Codigo", IsUnique = true)]
[Index("Descripcion", Name = "IX_TipoDocumento_Descripcion", IsUnique = true)]
public partial class TipoDocumento
{
    [Key]
    public int Id { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string Codigo { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Descripcion { get; set; } = null!;

    [InverseProperty("TipoDocumento")]
    public virtual ICollection<Persona> Personas { get; } = new List<Persona>();
}
