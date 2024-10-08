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
    public class ImagensController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ImagensController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/Imagens/5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Imagens>>> GetImagens(
            [FromQuery] int? id_produto,
            [FromQuery] int? id_avaliacao
            )
        {
            if(id_produto == null && id_avaliacao == null)
            {
                return BadRequest("Nenhum ID foi fornecido");
            }

            if (id_produto != null && id_avaliacao != null)
            {
                return BadRequest("Forneceu dois IDs, fornça somente um");
            }

            var query = _context.Imagens.AsQueryable();

            if(id_avaliacao != null)
            {
                query = query.Where(p => 
                    p.TipoImagem.Equals("Avaliacao") 
                    && p.Id_avaliacao == id_avaliacao);
            }

            if (id_produto != null)
            {
                query = query.Where(p =>
                    p.TipoImagem.Equals("Produto")
                    && p.Id_avaliacao == id_produto);
            }

            var fotos = await query.ToListAsync();

            if (fotos == null || fotos.Count == 0)
            {
                return NotFound();
            }

            return fotos;
        }

        // PUT: api/Imagens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImagens(int id, Imagens imagens)
        {
            if (id != imagens.Id)
            {
                return BadRequest();
            }

            _context.Entry(imagens).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImagensExists(id))
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

        // POST: api/Imagens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Imagens>> PostImagens(Imagens imagens)
        {
            _context.Imagens.Add(imagens);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImagens", new { id = imagens.Id }, imagens);
        }

        // DELETE: api/Imagens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImagens(int id)
        {
            var imagens = await _context.Imagens.FindAsync(id);
            if (imagens == null)
            {
                return NotFound();
            }

            _context.Imagens.Remove(imagens);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImagensExists(int id)
        {
            return _context.Imagens.Any(e => e.Id == id);
        }
    }
}
