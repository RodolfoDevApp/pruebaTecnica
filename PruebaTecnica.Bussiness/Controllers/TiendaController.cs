using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Bussiness.Repository;
using PruebaTecnica.Entities;

namespace PruebaTecnica.Pages
{
    [ApiController]
    [Route("[controller]")]
    public class TiendaController : ControllerBase
    {
        private readonly IRepository _repository;
        public TiendaController(IRepository Repository)
        {
            _repository = Repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTiendas()
        {
            var tiendas = await _repository.GetAllTiendasAsync();
            return Ok(tiendas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTienda(int id)
        {
            var tienda = await _repository.GetTiendaByIdAsync(id);
            if (tienda == null)
            {
                return NotFound();
            }
            return Ok(tienda);
        }

        [HttpPost]
        public async Task<IActionResult> AddTienda([FromBody] Tienda tienda)
        {
            await _repository.AddTiendaAsync(tienda);
            return CreatedAtAction("GetTienda", new { id = tienda.TiendaId }, tienda);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTienda(int id, [FromBody] Tienda tienda)
        {
            if (id != tienda.TiendaId)
            {
                return BadRequest();
            }
            await _repository.UpdateTiendaAsync(tienda);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTienda(int id)
        {
            await _repository.DeleteTiendaAsync(id);
            return NoContent();
        }

    }
}
