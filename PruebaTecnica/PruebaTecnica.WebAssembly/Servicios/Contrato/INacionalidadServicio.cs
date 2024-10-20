using PruebaTecnica.DTO;

namespace PruebaTecnica.WebAssembly.Servicios.Contrato
{
    public interface INacionalidadServicio
    {
        Task<RespuestaDTO<List<NacionalidadDTO>>> Lista(string buscar);
        Task<RespuestaDTO<NacionalidadDTO>> Obtener(int id);
        Task<RespuestaDTO<NacionalidadDTO>> Crear(NacionalidadDTO modelo);
        Task<RespuestaDTO<bool>> Editar(NacionalidadDTO modelo);
        Task<RespuestaDTO<bool>> Eliminar(int id);


    }
}
