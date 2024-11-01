using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace theStyleHub.Models;

public class ItensWishlist
{
    [Key]
    public int Id { get; set; }
    
    [ForeignKey("UsuarioId")]
    public Usuarios Usuario { get; set; }
    public int UsuarioId { get; set; }

    [ForeignKey("ProdutoId")]
    public Produtos Produto { get; set; }
    public int ProdutoId { get; set; }

}
