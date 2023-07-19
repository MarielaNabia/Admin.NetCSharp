using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RPA.Web;

public partial class Consorcio
{
    public int Id { get; set; }


    [Required(ErrorMessage = "Campo requerido")]
    [RegularExpression("/^(20|23|27|30|33)([0-9]{9}|-[0-9]{8}-[0-9]{1})$/g", ErrorMessage = "CUIT incorrecto")]
    [DisplayName("CUIT")]
    public string Cuit { get; set; } = null!;

    [Required(ErrorMessage = "Campo requerido")]
    [StringLength(200)]
    [DisplayName("Denominación")]
    public string Denominacion { get; set; } = null!;

    [DisplayName("Fecha de Alta")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
    public DateTime FechaAlta { get; set; }


    [DisplayName ("Fecha de Baja")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]

    public DateTime? FechaBaja { get; set; }

    public virtual ICollection<ConsorcioAdministrador> ConsorciosAdministradores { get; } = new List<ConsorcioAdministrador>();

    public virtual ICollection<ConsorcioDomicilio> ConsorciosDomicilios { get; } = new List<ConsorcioDomicilio>();
}
