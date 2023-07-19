using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RPA.Web;

public partial class EstadoMatricula
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Campo requerido")]
    [StringLength(50)]
    [DisplayName("Estado Matrícula")]
    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Administrador> Administradores { get; } = new List<Administrador>();
}