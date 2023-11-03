using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Bussiness.Repository;
using PruebaTecnica.Entities;

namespace PruebaTecnica.Pages
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IRepository _repository;

        public ClienteController(IRepository Repository)
        {
            _repository = Repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _repository.GetAllClientesAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(int id)
        {
            var cliente = await _repository.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> AddCliente([FromBody] Cliente cliente)
        {
            await _repository.AddClienteAsync(cliente);
            return CreatedAtAction("GetCliente", new { id = cliente.ClienteId }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, [FromBody] Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return BadRequest();
            }
            await _repository.UpdateClienteAsync(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            await _repository.DeleteClienteAsync(id);
            return NoContent();
        }
    }
}
