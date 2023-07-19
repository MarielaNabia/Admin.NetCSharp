using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RPA.Web.Models1;

public partial class ConsorciosDomicilio
{
    [Key]
    public int Id { get; set; }

    public int ConsorcioId { get; set; }

    public int DomicilioId { get; set; }

    public int TipoDomicilioId { get; set; }

    [Column(TypeName = "date")]
    public DateTime FechaAlta { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaBaja { get; set; }

    [ForeignKey("ConsorcioId")]
    [InverseProperty("ConsorciosDomicilios")]
    public virtual Consorcio Consorcio { get; set; } = null!;

    [ForeignKey("DomicilioId")]
    [InverseProperty("ConsorciosDomicilios")]
    public virtual Domicilio Domicilio { get; set; } = null!;

    [ForeignKey("TipoDomicilioId")]
    [InverseProperty("ConsorciosDomicilios")]
    public virtual TipoDomicilio TipoDomicilio { get; set; } = null!;
}
