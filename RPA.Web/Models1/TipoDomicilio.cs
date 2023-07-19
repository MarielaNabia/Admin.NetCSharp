using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RPA.Web.Models1;

[Table("TipoDomicilio")]
[Index("Descripcion", Name = "IX_TipoDomicilio_Descripcion", IsUnique = true)]
public partial class TipoDomicilio
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Descripcion { get; set; } = null!;

    [InverseProperty("TipoDomicilio")]
    public virtual ICollection<ConsorciosDomicilio> ConsorciosDomicilios { get; } = new List<ConsorciosDomicilio>();

    [InverseProperty("TipoDomicilio")]
    public virtual ICollection<PersonasDomicilio> PersonasDomicilios { get; } = new List<PersonasDomicilio>();
}
