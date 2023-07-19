using System;
using System.Collections.Generic;

namespace RPA.Domain.Entities;

public partial class TipoDocumento
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Persona> Personas { get; } = new List<Persona>();
}
