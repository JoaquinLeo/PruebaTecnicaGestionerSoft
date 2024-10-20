using System;
using System.Collections.Generic;

namespace PruebaTecnica.Modelo;

public partial class Deportista
{
    public int IdDeportista { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? Edad { get; set; }

    public string? Sexo { get; set; }

    public string? Imagen { get; set; }

    public int? IdNacionalidad { get; set; }

    public int? IdDeporte { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Deporte? IdDeporteNavigation { get; set; }

    public virtual Nacionalidad? IdNacionalidadNavigation { get; set; }
}
