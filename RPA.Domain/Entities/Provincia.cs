using System;
using System.Collections.Generic;

namespace RPA.Domain.Entities;

public partial class Provincia
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Domicilio> Domicilios { get; } = new List<Domicilio>();

    public virtual ICollection<Localidad> Localidades { get; } = new List<Localidad>();
}
