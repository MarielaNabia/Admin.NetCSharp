using System;
using System.Collections.Generic;

namespace RPA.Domain.Entities;

public partial class ConsorcioAdministrador
{
    public int Id { get; set; }

    public int ConsorcioId { get; set; }

    public int AdministradorId { get; set; }

    public DateTime FechaAlta { get; set; }

    public DateTime? FechaBaja { get; set; }

    public virtual Administrador Administrador { get; set; } = null!;

    public virtual Consorcio Consorcio { get; set; } = null!;
}
