using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RPA.Web;

public partial class PersonaDomicilio
{
    public int Id { get; set; }

    public int PersonaId { get; set; }

    public int DomicilioId { get; set; }

    public int TipoDomicilioId { get; set; }

    [Display(Name = "Fecha de Alta")]
    public DateTime FechaAlta { get; set; }

    [Display(Name = "Fecha de Baja")]
    public DateTime? FechaBaja { get; set; }

    public virtual Domicilio Domicilio { get; set; } = null!;

    public virtual Persona Persona { get; set; } = null!;

    [Display(Name = "Tipo de domicilio")]
    public virtual TipoDomicilio TipoDomicilio { get; set; } = null!;
}
