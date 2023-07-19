using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RPA.Web.Models1;

[Index("Matricula", Name = "IX_Administradores_Matricula", IsUnique = true)]
public partial class Administradore
{
    [Key]
    public int Id { get; set; }

    public int Matricula { get; set; }

    public bool Oneroso { get; set; }

    public int PersonaId { get; set; }

    [Column(TypeName = "date")]
    public DateTime FechaAlta { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaBaja { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaActualizacion { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaSuspencion { get; set; }

    [Column(TypeName = "text")]
    public string? Observaciones { get; set; }

    public int EstadoMatriculaId { get; set; }

    [InverseProperty("Administrador")]
    public virtual ICollection<ConsorciosAdministradore> ConsorciosAdministradores { get; } = new List<ConsorciosAdministradore>();

    [ForeignKey("EstadoMatriculaId")]
    [InverseProperty("Administradores")]
    public virtual EstadoMatricula EstadoMatricula { get; set; } = null!;

    [ForeignKey("PersonaId")]
    [InverseProperty("Administradores")]
    public virtual Persona Persona { get; set; } = null!;
}
