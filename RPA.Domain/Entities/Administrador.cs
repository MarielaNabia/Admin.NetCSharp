using System;
using System.Collections.Generic;

namespace RPA.Domain.Entities;

public partial class Administrador
{
    public int Id { get; set; }

    public int Matricula { get; set; }

    public bool Oneroso { get; set; }

    public int PersonaId { get; set; }

    public DateTime FechaAlta { get; set; }

    public DateTime? FechaBaja { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public DateTime? FechaSuspension { get; set; }

    public string? Observaciones { get; set; }

    public int EstadoMatriculaId { get; set; }

    public virtual ICollection<ConsorcioAdministrador> ConsorciosAdministradores { get; } = new List<ConsorcioAdministrador>();

    public virtual EstadoMatricula EstadoMatricula { get; set; } = null!;

    public virtual Persona Persona { get; set; } = null!;
}
