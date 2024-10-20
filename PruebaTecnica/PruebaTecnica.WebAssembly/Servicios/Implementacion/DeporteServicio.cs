using PruebaTecnica.DTO;
using PruebaTecnica.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;

namespace PruebaTecnica.WebAssembly.Servicios.Implementacion
{
    public class DeporteServicio : IDeporteServicio
    {
        private readonly HttpClient _httpClient;

        public DeporteServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RespuestaDTO<DeporteDTO>> Crear(DeporteDTO modelo)
        {
            var respuesta = await _httpClient.PostAsJsonAsync("Deporte/Crear", modelo);
            var resultado = await respuesta.Content.ReadFromJsonAsync<RespuestaDTO<DeporteDTO>>();
            return resultado!;
        }

        public async Task<RespuestaDTO<bool>> Editar(DeporteDTO modelo)
        {
            var respuesta = await _httpClient.PutAsJsonAsync("Deporte/Editar", modelo);
            var resultado = await respuesta.Content.ReadFromJsonAsync<RespuestaDTO<bool>>();
            return resultado!;
        }

        public async Task<RespuestaDTO<bool>> Eliminar(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<RespuestaDTO<bool>>($"Deporte/Eliminar/{id}");
        }

        public async Task<RespuestaDTO<List<DeporteDTO>>> Lista(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<RespuestaDTO<List<DeporteDTO>>>($"Deporte/Lista/{buscar}");
        }

        public async Task<RespuestaDTO<DeporteDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<RespuestaDTO<DeporteDTO>>($"Deporte/Obtener/{id}");
        }
    }
}
