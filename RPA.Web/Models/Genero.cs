using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RPA.Web;

public partial class Genero
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [StringLength(1)]
    [DisplayName("Código Género")]

    public string Codigo { get; set; } = null!;
    [Required(ErrorMessage = "Campo requerido")]
    [StringLength(10)]
    [DisplayName("Género")]
    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Persona> Personas { get; } = new List<Persona>();
}
