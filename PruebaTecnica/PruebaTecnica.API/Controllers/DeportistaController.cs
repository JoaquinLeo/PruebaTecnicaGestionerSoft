using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PruebaTecnica.Servicio.Contrato;
using PruebaTecnica.DTO;

namespace PruebaTecnica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeportistaController : ControllerBase
    {
        private readonly IDeportistaServicio _deportistaServicio;

        public DeportistaController(IDeportistaServicio deportistaServicio)
        {
            _deportistaServicio = deportistaServicio;
        }

        [HttpGet("Lista/{buscar?}")]
        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var respuesta = new RespuestaDTO<List<DeportistaDTO>>();

            try
            {
                if (buscar == "NA")
                {
                    buscar = "";
                }
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _deportistaServicio.Lista(buscar);

            }
            catch (Exception ex)
            {
                respuesta.EsCorrecto = false;
                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }

        [HttpGet("Obtener/{Id:int}")]
        public async Task<IActionResult> Obtener(int Id)
        {
            var respuesta = new RespuestaDTO<DeportistaDTO>();

            try
            {
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _deportistaServicio.Obtener(Id);
            }
            catch (Exception ex)
            {
                respuesta.EsCorrecto = false;
                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] DeportistaDTO modelo)
        {
            var respuesta = new RespuestaDTO<DeportistaDTO>();

            try
            {
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _deportistaServicio.Crear(modelo);
            }
            catch (Exception ex)
            {
                respuesta.EsCorrecto = false;
                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] DeportistaDTO modelo)
        {
            var respuesta = new RespuestaDTO<bool>();

            try
            {
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _deportistaServicio.Editar(modelo);
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
                respuesta.Resultado = await _deportistaServicio.Eliminar(Id);
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
