using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Modelo;

public partial class Deporte
{
    public int IdDeporte { get; set; }

    public string? Nombre { get; set; }

    public string? Tipo { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Deportista> Deportista { get; set; } = new List<Deportista>();

}
