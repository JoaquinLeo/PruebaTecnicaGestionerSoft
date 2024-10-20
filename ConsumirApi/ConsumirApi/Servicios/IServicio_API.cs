using ConsumirApi.Models;

namespace ConsumirApi.Servicios
{
    public interface IServicio_API
    {
        Task <List<Datos>> Lista(string peticion);
    }
}
