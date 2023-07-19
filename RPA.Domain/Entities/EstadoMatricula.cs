using System;
using System.Collections.Generic;

namespace RPA.Domain.Entities;

public partial class EstadoMatricula
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Administrador> Administradores { get; } = new List<Administrador>();
}
