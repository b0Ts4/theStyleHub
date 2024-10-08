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
    public class AvaliacoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AvaliacoesController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/Avaliacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Avaliacoes>> GetAvaliacoes(int id)
        {
            var avaliacoes = await _context.Avaliacoes.FindAsync(id);

            if (avaliacoes == null)
            {
                return NotFound();
            }

            return avaliacoes;
        }

        [HttpGet("/produto/{id}")]
        public async Task<ActionResult<IEnumerable<Avaliacoes>>> GetAvaliacoesProduto(int id)
        {
            var avaliacoes = await _context.Avaliacoes
                                           .Where(a => a.Id_produto == id)
                                           .ToListAsync();

            if (avaliacoes == null)
            {
                return NotFound();
            }

            return avaliacoes;
        }

        // PUT: api/Avaliacoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvaliacoes(int id, Avaliacoes avaliacoes)
        {
            if (id != avaliacoes.Id)
            {
                return BadRequest();
            }

            _context.Entry(avaliacoes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvaliacoesExists(id))
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

        // POST: api/Avaliacoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Avaliacoes>> PostAvaliacoes(Avaliacoes avaliacoes)
        {
            _context.Avaliacoes.Add(avaliacoes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAvaliacoes", new { id = avaliacoes.Id }, avaliacoes);
        }

        // DELETE: api/Avaliacoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvaliacoes(int id)
        {
            var avaliacoes = await _context.Avaliacoes.FindAsync(id);
            if (avaliacoes == null)
            {
                return NotFound();
            }

            _context.Avaliacoes.Remove(avaliacoes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AvaliacoesExists(int id)
        {
            return _context.Avaliacoes.Any(e => e.Id == id);
        }
    }
}
