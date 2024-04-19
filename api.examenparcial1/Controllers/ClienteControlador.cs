using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Services.Servicios;

namespace api.examenparcial1.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ClienteControlador : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ClienteService _clienteService;

        public ClienteControlador(IConfiguration configuration, ClienteService clienteService)
        {
            _configuration = configuration;
            _clienteService = clienteService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(ClienteModel cliente)
        {
            try
            {
                if (await _clienteService.Add(cliente))
                    return Ok("Cliente agregado correctamente");
                else
                    return BadRequest("No se pudo agregar Cliente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(ClienteModel cliente)
        {
            try
            {
                if (await _clienteService.Update(cliente))
                    return Ok("Cliente actualizado correctamente");
                else
                    return BadRequest("No se pudo actualizar Cliente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Remove/{id}")]

        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                if (await _clienteService.Remove(id))
                    return Ok("Cliente eliminado correctamente");
                else
                    return BadRequest("No se pudo eliminar Cliente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var cliente = await _clienteService.Get(id);
                if (cliente != null)
                    return Ok(cliente);
                else
                    return NotFound("No se pudo obtener Cliente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            try
            {
                var clientes = await _clienteService.List();
                if (clientes != null)
                    return Ok(clientes);
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