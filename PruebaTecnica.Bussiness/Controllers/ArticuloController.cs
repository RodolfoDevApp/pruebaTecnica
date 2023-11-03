using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Bussiness.Repository;
using PruebaTecnica.Entities;

namespace PruebaTecnica.Pages
{
    [ApiController]
    [Route("[controller]")]
    public class ArticuloController : ControllerBase
    {
        private readonly IRepository _repository;

        public ArticuloController(IRepository Repository)
        {
            _repository = Repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetArticulos()
        {
            var articulos = await _repository.GetAllArticulosAsync();
            return Ok(articulos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticulo(int id)
        {
            var articulo = await _repository.GetArticuloByIdAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }
            return Ok(articulo);
        }


        [HttpPost]
        public async Task<IActionResult> CreateArticulo([FromBody] Articulo articulo)
        {
            await _repository.AddArticuloAsync(articulo);
            return CreatedAtAction("GetArticulo", new { id = articulo.ArticuloId }, articulo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArticulo(int id, [FromBody] Articulo articulo)
        {
            if (id != articulo.ArticuloId)
            {
                return BadRequest();
            }

            await _repository.UpdateArticuloAsync(articulo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticulo(int id)
        {
            await _repository.DeleteArticuloAsync(id);
            return NoContent();
        }
        [HttpPost("cliente/articulo")]
        public async Task<IActionResult> clienteArticulo([FromBody] RelacionClienteArticulo articulo)
        {
            await _repository.AddCAAsync(articulo);
            return CreatedAtAction("GetArticulo", new { id = articulo.ArticuloId }, articulo);
        }
        [HttpGet("cliente/articulo/{id}")]
        public async Task<IActionResult> getProductosCliente(int id)
        {
            var articulo = await _repository.getProductosCAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }
            return Ok(articulo);
        }
    }
}
