using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PruebaTecnica.Servicio.Contrato;
using PruebaTecnica.DTO;
using PruebaTecnica.Servicio.Implementacion;

namespace PruebaTecnica.API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class DeporteController : ControllerBase
    {
        private readonly IDeporteServicio _deporteServicio;

        public DeporteController(IDeporteServicio deporteServicio)
        {
            _deporteServicio = deporteServicio;
        }


        [HttpGet("Lista/{buscar?}")]
        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var respuesta = new RespuestaDTO<List<DeporteDTO>>();

            try
            {
                if (buscar == "NA")
                {
                    buscar = "";
                }
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _deporteServicio.Lista(buscar);

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
            var respuesta = new RespuestaDTO<DeporteDTO>();

            try
            {
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _deporteServicio.Obtener(Id);
            }
            catch (Exception ex)
            {
                respuesta.EsCorrecto = false;
                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] DeporteDTO modelo)
        {
            var respuesta = new RespuestaDTO<DeporteDTO>();

            try
            {
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _deporteServicio.Crear(modelo);
            }
            catch (Exception ex)
            {
                respuesta.EsCorrecto = false;
                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] DeporteDTO modelo)
        {
            var respuesta = new RespuestaDTO<bool>();

            try
            {
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _deporteServicio.Editar(modelo);
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
                respuesta.Resultado = await _deporteServicio.Eliminar(Id);
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
