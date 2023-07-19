using System;
using System.Collections.Generic;

namespace RPA.Domain.Entities;

public partial class Consorcio
{
    public int Id { get; set; }

    public int Cuit { get; set; }

    public string Denominacion { get; set; } = null!;

    public DateTime FechaAlta { get; set; }

    public DateTime? FechaBaja { get; set; }

    public virtual ICollection<ConsorcioAdministrador> ConsorciosAdministradores { get; } = new List<ConsorcioAdministrador>();

    public virtual ICollection<ConsorcioDomicilio> ConsorciosDomicilios { get; } = new List<ConsorcioDomicilio>();
}
