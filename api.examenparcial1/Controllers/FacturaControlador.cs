using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Services.Servicios;

namespace api.examenparcial1.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class FacturaControlador : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly FacturaService _facturaService;

        public FacturaControlador(IConfiguration configuration, FacturaService facturaService)
        {
            _configuration = configuration;
            _facturaService = facturaService;
        }

        [HttpPost("Agregar")]
        public async Task<IActionResult> Add(FacturaModel factura)
        {
            try
            {
                if (await _facturaService.Add(factura))
                    return Ok("Factura agregada correctamente");
                else
                    return BadRequest("Error al agregar cliente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Modificar")]
        public async Task<IActionResult> Update(FacturaModel factura)
        {
            try
            {
                if (await _facturaService.Update(factura))
                    return Ok("Factura actualizada correctamente");
                else
                    return BadRequest("Error al actualizar factura");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]

        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                if (await _facturaService.Remove(id))
                    return Ok("Factura eliminada correctamente");
                else
                    return BadRequest("Error al eliminar cliente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Consultar/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var factura = await _facturaService.Get(id);
                if (factura != null)
                    return Ok(factura);
                else
                    return NotFound("Factura no encontrada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> List()
        {
            try
            {
                var factura = await _facturaService.List();
                if (factura != null)
                    return Ok(factura);
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
