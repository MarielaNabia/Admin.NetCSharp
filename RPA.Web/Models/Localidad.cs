using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RPA.Web;

public partial class Localidad
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [StringLength(50)]
    [DisplayName("Localidad")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "Campo requerido")]
    public int ProvinciaId { get; set; }

    public virtual ICollection<Domicilio> Domicilios { get; } = new List<Domicilio>();

    public virtual Provincia? Provincia { get; set; }
}