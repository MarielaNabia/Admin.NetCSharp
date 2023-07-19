using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RPA.Web;

public partial class _Persona 
{
    public int Id { get; set; }

    public int TipoPersonaId { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    //[RegularExpression("/^(20|23|27)([0-9]{9}|-[0-9]{8}-[0-9]{1})$/g", ErrorMessage = "CUIL incorrecto")]
    [DisplayName("CUIL")]
    public string CuitCuil { get; set; } = null!;

    [Display(Name = "Razón Social")]
    [StringLength(200)]
    public string? RazonSocial { get; set; } 

    [StringLength(50)]
    public string? Nombre { get; set; } 

    [StringLength(50)]
    public string? Apellido { get; set; } 

    [Display(Name = "Tipo de Documento")]
    public int? TipoDocumentoId { get; set; }


    [Display(Name = "Número de Documento")]
    public int? NumeroDocumento { get; set; }

    public int? GeneroId { get; set; }

    [Display(Name = "Fecha de Nacimiento")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
    public DateTime? FechaNacimiento { get; set; }

    [Display(Name = "Género")]
    public virtual Genero Genero { get; set; } = null!;

    public virtual TipoPersona TipoPersona { get; set; } = null!;

    public virtual TipoDocumento TipoDocumento { get; set; }


    [StringLength(20)]
    [DisplayName("Telefono 1")]
    public string? Telefono1 { get; set; }

    [StringLength(20)]
    [DisplayName("Te   lefono 2")]
    public string? Telefono2 { get; set; }

    [StringLength(20)]
    [DisplayName("Celular 1")]
    public string? Celular1 { get; set; }

    [StringLength(20)]
    [DisplayName("Celular 2")]
    public string? Celular2 { get; set; }

    [StringLength(50)]
    [DisplayName("E-mail 1")]
    [EmailAddress(ErrorMessage = "Ingrese un email correcto")]
    public string? Email1 { get; set; }

    [StringLength(50)]
    [DisplayName("E-mail 2")]
    [EmailAddress(ErrorMessage = "Ingrese un email correcto")]
    public string? Email2 { get; set; }

    public virtual ICollection<Administrador> Administradores { get; } = new List<Administrador>();

    public virtual ICollection<PersonaDomicilio> PersonasDomicilios { get; } = new List<PersonaDomicilio>();


  


}
