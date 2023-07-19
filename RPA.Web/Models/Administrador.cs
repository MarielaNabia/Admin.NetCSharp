using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RPA.Web;

public partial class Administrador
{
    public int Id { get; set; }


    [DisplayName("Matrícula")]
    [Required(ErrorMessage = "Campo requerido")]
    [StringLength(30, MinimumLength = 12)]
    public int Matricula { get; set; }

    public bool Oneroso { get; set; }
    [Display(Name = "Persona")]
    public int PersonaId { get; set; }


    [DisplayName("Fecha Alta")]
    [Required(ErrorMessage = "Campo requerido")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime FechaAlta { get; set; }



    [DisplayName("Fecha Baja")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

    public DateTime? FechaBaja { get; set; }

    [DisplayName("Fecha Actualización")]

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

    public DateTime? FechaActualizacion { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [DisplayName("Fecha Suspensión")]
    public DateTime? FechaSuspension { get; set; }

    [StringLength(60)]
    public string? Observaciones { get; set; }

    [DisplayName( "Estado Matrícula")]
    public int EstadoMatriculaId { get; set; }

    [DisplayName( "Consorcios Administradores")]
    public virtual ICollection<ConsorcioAdministrador> ConsorciosAdministradores { get; } = new List<ConsorcioAdministrador>();

    [DisplayName("Estado Matrícula")]
    [Required(ErrorMessage = "Campo requerido")]
    public virtual EstadoMatricula EstadoMatricula { get; set; } = null!;

    public virtual Persona Persona { get; set; } = null!;
}








  