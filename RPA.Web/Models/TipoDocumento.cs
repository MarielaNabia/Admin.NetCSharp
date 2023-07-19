using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RPA.Web;

public partial class TipoDocumento
{
    public int Id { get; set; }

    [Display(Name = "Tipo")]
    public string Codigo { get; set; } = null!;

    [Display(Name = "Descripción")]
    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Persona> Personas { get; } = new List<Persona>();
}
