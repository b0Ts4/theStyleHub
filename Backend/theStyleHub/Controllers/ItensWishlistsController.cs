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
    public class ItensWishlistsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ItensWishlistsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ItensWishlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItensWishlist>>> GetItensWishlist()
        {
            return await _context.ItensWishlist.ToListAsync();
        }

        // GET: api/ItensWishlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItensWishlist>> GetItensWishlist(int id)
        {
            var itensWishlist = await _context.ItensWishlist.FindAsync(id);

            if (itensWishlist == null)
            {
                return NotFound();
            }

            return itensWishlist;
        }

        // PUT: api/ItensWishlists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItensWishlist(int id, ItensWishlist itensWishlist)
        {
            if (id != itensWishlist.Id)
            {
                return BadRequest();
            }

            _context.Entry(itensWishlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItensWishlistExists(id))
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

        // POST: api/ItensWishlists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItensWishlist>> PostItensWishlist(ItensWishlist itensWishlist)
        {
            _context.ItensWishlist.Add(itensWishlist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItensWishlist", new { id = itensWishlist.Id }, itensWishlist);
        }

        // DELETE: api/ItensWishlists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItensWishlist(int id)
        {
            var itensWishlist = await _context.ItensWishlist.FindAsync(id);
            if (itensWishlist == null)
            {
                return NotFound();
            }

            _context.ItensWishlist.Remove(itensWishlist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItensWishlistExists(int id)
        {
            return _context.ItensWishlist.Any(e => e.Id == id);
        }
    }
}
