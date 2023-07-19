using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RPA.Web.Models1;

public partial class ConsorciosAdministradore
{
    [Key]
    public int Id { get; set; }

    public int ConsorcioId { get; set; }

    public int AdministradorId { get; set; }

    [Column(TypeName = "date")]
    public DateTime FechaAlta { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaBaja { get; set; }

    [ForeignKey("AdministradorId")]
    [InverseProperty("ConsorciosAdministradores")]
    public virtual Administradore Administrador { get; set; } = null!;

    [ForeignKey("ConsorcioId")]
    [InverseProperty("ConsorciosAdministradores")]
    public virtual Consorcio Consorcio { get; set; } = null!;
}
