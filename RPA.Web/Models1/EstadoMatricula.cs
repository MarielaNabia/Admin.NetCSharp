using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RPA.Web.Models1;

[Table("EstadoMatricula")]
[Index("Descripcion", Name = "IX_EstadoMatricula_Descripcion", IsUnique = true)]
public partial class EstadoMatricula
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Descripcion { get; set; } = null!;

    [InverseProperty("EstadoMatricula")]
    public virtual ICollection<Administradore> Administradores { get; } = new List<Administradore>();
}
