using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PruebaTecnica.DTO;

namespace PruebaTecnica.Servicio.Contrato
{
    public interface IDeportistaServicio
    {
        Task<List<DeportistaDTO>> Lista(string buscar);

        Task<DeportistaDTO> Obtener(int id);
        Task<DeportistaDTO> Crear(DeportistaDTO modelo);
        Task<bool> Editar(DeportistaDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
