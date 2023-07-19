using System;
using System.Collections.Generic;

namespace RPA.Domain.Entities;

public partial class Localidad
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int ProvinciaId { get; set; }

    public virtual ICollection<Domicilio> Domicilios { get; } = new List<Domicilio>();

    public virtual Provincia Provincia { get; set; } = null!;
}
