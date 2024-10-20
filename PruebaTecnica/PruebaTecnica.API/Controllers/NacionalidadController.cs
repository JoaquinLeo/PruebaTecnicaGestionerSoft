using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PruebaTecnica.Servicio.Contrato;
using PruebaTecnica.DTO;

namespace PruebaTecnica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NacionalidadController : ControllerBase
    {
        private readonly INacionalidadServicio _nacionalidadServicio;

        public NacionalidadController(INacionalidadServicio nacionalidadServicio)
        {
            _nacionalidadServicio = nacionalidadServicio;
        }

        [HttpGet("Lista/{buscar?}")]
        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var respuesta = new RespuestaDTO<List<NacionalidadDTO>>();

            try
            {
                if (buscar == "NA")
                {
                    buscar = "";
                }
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _nacionalidadServicio.Lista(buscar);

            }catch (Exception ex)
            {
                respuesta.EsCorrecto = false;
                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }

        [HttpGet("Obtener/{Id:int}")]
        public async Task<IActionResult> Obtener(int Id)
        {
            var respuesta = new RespuestaDTO<NacionalidadDTO>();

            try
            {
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _nacionalidadServicio.Obtener(Id);
            }
            catch (Exception ex)
            {
                respuesta.EsCorrecto = false;
                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody]NacionalidadDTO modelo)
        {
            var respuesta = new RespuestaDTO<NacionalidadDTO>();

            try
            {
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _nacionalidadServicio.Crear(modelo);
            }
            catch (Exception ex)
            {
                respuesta.EsCorrecto = false;
                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] NacionalidadDTO modelo)
        {
            var respuesta = new RespuestaDTO<bool>();

            try
            {
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _nacionalidadServicio.Editar(modelo);
            }
            catch (Exception ex)
            {
                respuesta.EsCorrecto = false;
                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }

        [HttpDelete("Eliminar/{Id:int}")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            var respuesta = new RespuestaDTO<bool>();

            try
            {
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _nacionalidadServicio.Eliminar(Id);
            }
            catch (Exception ex)
            {
                respuesta.EsCorrecto = false;
                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }

    }
}
