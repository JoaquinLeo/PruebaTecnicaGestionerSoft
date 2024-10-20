using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.DTO
{
    public class DeporteDTO
    {
        public int IdDeporte { get; set; }

        [Required(ErrorMessage = "Ingrese el deporte")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese el tipo")]
        public string? Tipo { get; set; }
        [Required(ErrorMessage = "Ingrese una descripcion")]
        public string? Descripcion { get; set; }
    }
}
