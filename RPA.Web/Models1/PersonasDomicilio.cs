using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RPA.Web.Models1;

public partial class PersonasDomicilio
{
    [Key]
    public int Id { get; set; }

    public int PersonaId { get; set; }

    public int DomicilioId { get; set; }

    public int TipoDomicilioId { get; set; }

    [Column(TypeName = "date")]
    public DateTime FechaAlta { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaBaja { get; set; }

    [ForeignKey("DomicilioId")]
    [InverseProperty("PersonasDomicilios")]
    public virtual Domicilio Domicilio { get; set; } = null!;

    [ForeignKey("PersonaId")]
    [InverseProperty("PersonasDomicilios")]
    public virtual Persona Persona { get; set; } = null!;

    [ForeignKey("TipoDomicilioId")]
    [InverseProperty("PersonasDomicilios")]
    public virtual TipoDomicilio TipoDomicilio { get; set; } = null!;
}
