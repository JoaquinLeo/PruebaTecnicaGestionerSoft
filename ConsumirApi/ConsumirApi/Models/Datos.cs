using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ConsumirApi.Models
{
    public class Datos
    {
        [JsonProperty("d")]
        [JsonPropertyName("d")]
        public string d {  get; set; }

        [JsonProperty("v")]
        [JsonPropertyName("v")]
        public string v { get; set; }
    }
}
