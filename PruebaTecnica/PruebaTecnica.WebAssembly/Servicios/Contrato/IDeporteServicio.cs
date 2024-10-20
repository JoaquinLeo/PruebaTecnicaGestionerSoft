using PruebaTecnica.DTO;

namespace PruebaTecnica.WebAssembly.Servicios.Contrato
{
    public interface IDeporteServicio
    {
        Task<RespuestaDTO<List<DeporteDTO>>> Lista(string buscar);
        Task<RespuestaDTO<DeporteDTO>> Obtener(int id);
        Task<RespuestaDTO<DeporteDTO>> Crear(DeporteDTO modelo);
        Task<RespuestaDTO<bool>> Editar(DeporteDTO modelo);
        Task<RespuestaDTO<bool>> Eliminar(int id);
    }
}
