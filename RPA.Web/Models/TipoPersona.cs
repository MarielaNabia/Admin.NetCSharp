using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RPA.Web;

public partial class TipoPersona
{
    public int Id { get; set; }

    [Display(Name = "Tipo de Personas")]
    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Persona> Personas { get; } = new List<Persona>();
}
