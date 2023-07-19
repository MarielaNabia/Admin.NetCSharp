using System;
using System.Collections.Generic;

namespace RPA.Web;

public partial class TipoDomicilio
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<ConsorcioDomicilio> ConsorciosDomicilios { get; } = new List<ConsorcioDomicilio>();

    public virtual ICollection<PersonaDomicilio> PersonasDomicilios { get; } = new List<PersonaDomicilio>();
}
