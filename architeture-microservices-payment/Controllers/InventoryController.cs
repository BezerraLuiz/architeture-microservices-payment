using architeture_microservices_payment.Data;
using architeture_microservices_payment.Models;
using Microsoft.AspNetCore.Mvc;

namespace architeture_microservices_payment.Controllers
{
    [ApiController] // Marca a classe como um controlador de API.
    [Route("api/[controller]")] // Define a rota base para "/api/inventory".
    public class InventoryController : ControllerBase
    {
        private readonly PaymentDbContext _context;

        // Injeta o contexto do banco de dados.
        public InventoryController(PaymentDbContext context)
        {
            _context = context;
        }

        // Retorna todos os itens do inventário.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetAllInventory()
        {
            return Ok(await Task.FromResult(_context.Inventories.ToList()));
        }

        // Retorna um item específico pelo ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<Inventory>> GetInventoryById(int id)
        {
            var item = await Task.FromResult(_context.Inventories.Find(id));
            if (item == null) return NotFound(); // Retorna 404 se não encontrado.
            return Ok(item);
        }

        // Cria um novo item no inventário.
        [HttpPost]
        public async Task<ActionResult<Inventory>> CreateInventory([FromBody] Inventory inventory)
        {
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();
            // Retorna o item criado com status 201.
            return CreatedAtAction(nameof(GetInventoryById), new { id = inventory.Id }, inventory);
        }

        // Atualiza um item existente.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInventory(int id, [FromBody] Inventory inventory)
        {
            if (id != inventory.Id) return BadRequest(); // Verifica ID.
            _context.Entry(inventory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                if (!_context.Inventories.Any(e => e.Id == id)) return NotFound(); // Verifica se o item existe.
                throw;
            }

            return NoContent(); // Retorna 204 em caso de sucesso.
        }

        // Deleta um item do inventário.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventory(int id)
        {
            var item = await Task.FromResult(_context.Inventories.Find(id));
            if (item == null) return NotFound(); // Retorna 404 se não encontrado.
            _context.Inventories.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent(); // Retorna 204 após remoção.
        }
    }
}
