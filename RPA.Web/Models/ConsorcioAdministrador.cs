using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RPA.Web;

public partial class ConsorcioAdministrador
{
    public int Id { get; set; }

    public int ConsorcioId { get; set; }
    public int AdministradorId { get; set; }

    [DisplayName("Fecha Alta")]

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

    public DateTime FechaAlta { get; set; }

    [DisplayName("Fecha Baja")]

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

    public DateTime? FechaBaja { get; set; }

    [DisplayName("Administrador")]

    public virtual Administrador Administrador { get; set; } = null!;
    [DisplayName("Consorcio")]
    public virtual Consorcio Consorcio { get; set; } = null!;
}