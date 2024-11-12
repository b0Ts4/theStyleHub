using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using theStyleHub.Models;

namespace theStyleHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItensCarrinhoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ItensCarrinhoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ItensCarrinhoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItensCarrinho>>> GetItensCarrinho()
        {
            return await _context.ItensCarrinho.ToListAsync();
        }

        // GET: api/ItensCarrinhoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItensCarrinho>> GetItensCarrinho(int id)
        {
            var itensCarrinho = await _context.ItensCarrinho.FindAsync(id);

            if (itensCarrinho == null)
            {
                return NotFound();
            }

            return itensCarrinho;
        }

        // PUT: api/ItensCarrinhoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItensCarrinho(int id, ItensCarrinho itensCarrinho)
        {
            if (id != itensCarrinho.Id)
            {
                return BadRequest();
            }

            _context.Entry(itensCarrinho).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItensCarrinhoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ItensCarrinhoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItensCarrinho>> PostItensCarrinho(int userId, int productId)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(p => p.Clerk_id == userId);
            var product = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == userId);
            if (product == null)
            {
                return BadRequest("O produto especificado não existe.");
            }

            var itensCarrinho = new ItensCarrinho();
            itensCarrinho.ProdutoId = productId;
            itensCarrinho.UsuarioId = userId;
            itensCarrinho.Produto = product;
            itensCarrinho.Usuario = user;
            _context.ItensCarrinho.Add(itensCarrinho);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItensCarrinho", new { id = itensCarrinho.Id }, itensCarrinho);
        }

        // DELETE: api/ItensCarrinhoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItensCarrinho(int id)
        {
            var itensCarrinho = await _context.ItensCarrinho.FindAsync(id);
            if (itensCarrinho == null)
            {
                return NotFound();
            }

            _context.ItensCarrinho.Remove(itensCarrinho);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItensCarrinhoExists(int id)
        {
            return _context.ItensCarrinho.Any(e => e.Id == id);
        }
    }
}
