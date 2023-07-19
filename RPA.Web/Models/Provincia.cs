using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RPA.Web;

public partial class Provincia
{
    public int Id { get; set; }
    [DisplayName("Provincia")]
    public string Nombre { get; set; } = null!;

    public virtual ICollection<Domicilio> Domicilios { get; } = new List<Domicilio>();

    public virtual ICollection<Localidad> Localidades { get; } = new List<Localidad>();
}
