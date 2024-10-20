using PruebaTecnica.DTO;
using PruebaTecnica.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;

namespace PruebaTecnica.WebAssembly.Servicios.Implementacion
{
    public class DeportistaServicio : IDeportistaServicio
    {
        private readonly HttpClient _httpClient;

        public DeportistaServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RespuestaDTO<DeportistaDTO>> Crear(DeportistaDTO modelo)
        {
            var respuesta = await _httpClient.PostAsJsonAsync("Deportista/Crear", modelo);
            var resultado = await respuesta.Content.ReadFromJsonAsync<RespuestaDTO<DeportistaDTO>>();
            return resultado!;
        }

        public async Task<RespuestaDTO<bool>> Editar(DeportistaDTO modelo)
        {
            var respuesta = await _httpClient.PutAsJsonAsync("Deportista/Editar", modelo);
            var resultado = await respuesta.Content.ReadFromJsonAsync<RespuestaDTO<bool>>();
            return resultado!;
        }

        public async Task<RespuestaDTO<bool>> Eliminar(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<RespuestaDTO<bool>>($"Deportista/Eliminar/{id}");
        }

        public async Task<RespuestaDTO<List<DeportistaDTO>>> Lista(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<RespuestaDTO<List<DeportistaDTO>>>($"Deportista/Lista/{buscar}");
        }

        public async Task<RespuestaDTO<DeportistaDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<RespuestaDTO<DeportistaDTO>>($"Deportista/Obtener/{id}");
        }
    }
}
