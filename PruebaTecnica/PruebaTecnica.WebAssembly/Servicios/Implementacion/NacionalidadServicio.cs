using PruebaTecnica.DTO;
using PruebaTecnica.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace PruebaTecnica.WebAssembly.Servicios.Implementacion
{
    public class NacionalidadServicio : INacionalidadServicio
    {
        private readonly HttpClient _httpClient;

        public NacionalidadServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RespuestaDTO<NacionalidadDTO>> Crear(NacionalidadDTO modelo)
        {
            var respuesta = await _httpClient.PostAsJsonAsync("Nacionalidad/Crear", modelo);
            var resultado = await respuesta.Content.ReadFromJsonAsync<RespuestaDTO<NacionalidadDTO>>();
            return resultado!;
        }

        public async Task<RespuestaDTO<bool>> Editar(NacionalidadDTO modelo)
        {
            var respuesta = await _httpClient.PutAsJsonAsync("Nacionalidad/Editar", modelo);
            var resultado = await respuesta.Content.ReadFromJsonAsync<RespuestaDTO<bool>>();
            return resultado!;
        }

        public async Task<RespuestaDTO<bool>> Eliminar(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<RespuestaDTO<bool>>($"Nacionalidad/Eliminar/{id}"); 
        }

        public async Task<RespuestaDTO<List<NacionalidadDTO>>> Lista(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<RespuestaDTO<List<NacionalidadDTO>>>($"Nacionalidad/Lista/{buscar}");
        }

        public async Task<RespuestaDTO<NacionalidadDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<RespuestaDTO<NacionalidadDTO>>($"Nacionalidad/Obtener/{id}");
        }
    }
}
