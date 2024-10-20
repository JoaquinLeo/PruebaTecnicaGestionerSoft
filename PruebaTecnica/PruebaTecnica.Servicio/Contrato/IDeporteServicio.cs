using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PruebaTecnica.DTO;

namespace PruebaTecnica.Servicio.Contrato
{
    public interface IDeporteServicio
    {
        Task<List<DeporteDTO>> Lista(string buscar);

        Task<DeporteDTO> Obtener(int id);
        Task<DeporteDTO> Crear(DeporteDTO modelo);
        Task<bool> Editar(DeporteDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
