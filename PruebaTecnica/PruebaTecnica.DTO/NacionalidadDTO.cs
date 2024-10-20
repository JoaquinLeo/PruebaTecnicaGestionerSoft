using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.DTO
{
    public class NacionalidadDTO
    {
        public int IdNacionalidad { get; set; }

        [Required(ErrorMessage = "Ingrese la Nacionalidad")]
        public string? Nombre { get; set; }
    }
}
