using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PruebaTecnica.DTO;

namespace PruebaTecnica.Servicio.Contrato
{
    public interface INacionalidadServicio
    {
        Task<List<NacionalidadDTO>> Lista(string buscar);

        Task<NacionalidadDTO> Obtener(int id);
        Task<NacionalidadDTO> Crear(NacionalidadDTO modelo);
        Task<bool> Editar(NacionalidadDTO modelo);
        Task<bool> Eliminar(int id);

    }
}
