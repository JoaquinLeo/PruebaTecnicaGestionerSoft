using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.DTO
{
    public class DeportistaDTO
    {
        public int IdDeportista { get; set; }
        [Required(ErrorMessage = "Ingrese el nombre")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese el apellido")]
        public string? Apellido { get; set; }
        [Required(ErrorMessage = "Ingrese la edad")]
        public int? Edad { get; set; }
        [Required(ErrorMessage = "Seleccione el sexo")]
        public string? Sexo { get; set; }
        [Required(ErrorMessage = "Ingrese la imagen")]
        public string? Imagen { get; set; }

        public int? IdNacionalidad { get; set; }

        public int? IdDeporte { get; set; }

        public virtual DeporteDTO? IdDeporteNavigation { get; set; }

        public virtual NacionalidadDTO? IdNacionalidadNavigation { get; set; }
    }
}
