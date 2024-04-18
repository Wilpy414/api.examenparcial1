using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;

namespace api.examenparcial1.Controllers
{
    public class ClienteControlador : Controller
    {
        private IConfiguration configuration;
        private ClienteRepository clienteRepository;

        /*public ClienteController()*/
        public ClienteControlador(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.clienteRepository = new ClienteRepository(configuration.GetConnectionString("postgresDB"));
        }
        // Generate crud controller
        [HttpPost]
        [Route("add")]
        public IActionResult add(ClienteModel cliente)
        {
            try
            {
                if (clienteRepository.add(cliente))
                    return Ok("Cliente agregado correctamente");
                else
                    return BadRequest("Error al agregar cliente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("update")]
        public IActionResult update(ClienteModel cliente, int id)
        {
            try
            {
                if (clienteRepository.update(cliente))
                    return Ok("Cliente actualizado correctamente");
                else
                    return BadRequest("Error al actualizar cliente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("remove")]
        public IActionResult remove(int id)
        {
            try
            {
                if (clienteRepository.remove(id))
                    return Ok("Cliente eliminado correctamente");
                else
                    return BadRequest("Error al eliminar cliente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("get/{id}")]
        public IActionResult get(int id)
        {
            try
            {
                var cliente = clienteRepository.get(id);
                if (cliente != null)
                    return Ok(cliente);
                else
                    return BadRequest("Cliente no encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("list")]
        public IActionResult list()
        {
            try
            {
                var clientes = clienteRepository.list();
                if (clientes != null)
                    return Ok(clientes);
                else
                    return BadRequest("No hay clientes registrados");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}