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
    public class ProdutosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Produtos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produtos>> GetProdutos(int id)
        {
            var produtos = await _context.Produtos.FindAsync(id);

            if (produtos == null)
            {
                return NotFound();
            }

            return produtos;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produtos>>> GetProdutosPeloFiltro(
        [FromQuery] string? genero,
        [FromQuery] string? categoria,
        [FromQuery] string? cor)
        {
            var query = _context.Produtos.AsQueryable();

            if (!string.IsNullOrEmpty(genero))
            {
                query = query.Where(p => p.Genero == genero);
            }

            if (!string.IsNullOrEmpty(categoria))
            {
                query = query.Where(p => p.Categoria == categoria);
            }

            if (!string.IsNullOrEmpty(cor))
            {
                query = query.Where(p => p.Cor == cor);
            }

            var produtos = await query.ToListAsync();

            if (produtos == null || produtos.Count == 0)
            {
                return NotFound();
            }

            return produtos;
        }

        // PUT: api/Produtos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdutos(int id, Produtos produtos)
        {
            if (id != produtos.Id)
            {
                return BadRequest();
            }

            _context.Entry(produtos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutosExists(id))
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

        // POST: api/Produtos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Consumes("application/json")]
        public async Task<ActionResult<Produtos>> PostProdutos([FromBody] ProdutoDTO produtoDTO)
        {
            

            var produto = new Produtos
            {
                Nome = produtoDTO.Nome,
                Descricao = produtoDTO.Descricao,
                Categoria = produtoDTO.Categoria,
                Cor = produtoDTO.Cor,
                Genero = produtoDTO.Genero,
                Valor = produtoDTO.Valor,
                Promocao = produtoDTO.Promocao
            };

            
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            
            if (produtoDTO.ImagensBase64 != null && produtoDTO.ImagensBase64.Count > 0)
            {
                
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);  
                }

                foreach (var base64Image in produtoDTO.ImagensBase64)
                {
                    
                    var imageBytes = Convert.FromBase64String(base64Image);
                    var caminhoImagem = Path.Combine(uploadsFolder, Guid.NewGuid().ToString() + ".jpg");

                    
                    await System.IO.File.WriteAllBytesAsync(caminhoImagem, imageBytes);
                    Console.WriteLine(caminhoImagem);
                    
                    var imagemProduto = new Imagens
                    {
                        Caminho = caminhoImagem,  
                        TipoImagem = "Produto",
                        Id_produto = produto.Id  
                    };

                    
                    _context.Imagens.Add(imagemProduto);
                }
            }

           
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdutos", new { id = produto.Id }, produto);
        }


        // DELETE: api/Produtos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdutos(int id)
        {
            var produtos = await _context.Produtos.FindAsync(id);
            if (produtos == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produtos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutosExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}
