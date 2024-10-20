using ConsumirApi.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;

namespace ConsumirApi.Servicios
{
    public class Servicio_API : IServicio_API
    {
        private static string _baseUrl;
        private static string _token;

        public Servicio_API()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
            _token = builder.GetSection("ApiSettings:token").Value;
        }

        public async Task<List<Datos>> Lista(string peticion)
        {
            List<Datos> lista = new List<Datos>();
            List<Datos> listasecundaria = new List<Datos>();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("BEARER", _token);
            var respuesta = await cliente.GetAsync(peticion);
    

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                //var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);
                //lista = resultado.lista;
                listasecundaria = JsonConvert.DeserializeObject<List<Datos>>(json_respuesta);
                
            }


            return listasecundaria;



        }
    }
}
