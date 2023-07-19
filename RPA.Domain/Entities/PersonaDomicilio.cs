using System;
using System.Collections.Generic;

namespace RPA.Domain.Entities;

public partial class PersonaDomicilio
{
    public int Id { get; set; }

    public int PersonaId { get; set; }

    public int DomicilioId { get; set; }

    public int TipoDomicilioId { get; set; }

    public DateTime FechaAlta { get; set; }

    public DateTime? FechaBaja { get; set; }

    public virtual Domicilio Domicilio { get; set; } = null!;

    public virtual Persona Persona { get; set; } = null!;

    public virtual TipoDomicilio TipoDomicilio { get; set; } = null!;
}
