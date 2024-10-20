using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Modelo;

public partial class Nacionalidad
{
    public int IdNacionalidad { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Deportista> Deportista { get; set; } = new List<Deportista>();

}
