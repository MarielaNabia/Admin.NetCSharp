using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RPA.Web;

public partial class ConsorcioDomicilio
{
    public int Id { get; set; }
    public int ConsorcioId { get; set; }
    public int DomicilioId { get; set; }
    public int TipoDomicilioId { get; set; }

    [DisplayName("Fecha Alta")]
    [Required(ErrorMessage = "Campo requerido")]

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime FechaAlta { get; set; }

    [DisplayName("Fecha Baja")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? FechaBaja { get; set; }

    public virtual Consorcio Consorcio { get; set; } = null!;
    public virtual Domicilio Domicilio { get; set; } = null!;
    [DisplayName("Tipo Domicilio")]
    [Required(ErrorMessage = "Campo requerido")]
    public virtual TipoDomicilio TipoDomicilio { get; set; } = null!;
}