using PruebaTecnica.DTO;

namespace PruebaTecnica.WebAssembly.Servicios.Contrato
{
    public interface IDeportistaServicio
    {
        Task<RespuestaDTO<List<DeportistaDTO>>> Lista(string buscar);
        Task<RespuestaDTO<DeportistaDTO>> Obtener(int id);
        Task<RespuestaDTO<DeportistaDTO>> Crear(DeportistaDTO modelo);
        Task<RespuestaDTO<bool>> Editar(DeportistaDTO modelo);
        Task<RespuestaDTO<bool>> Eliminar(int id);
    }
}
