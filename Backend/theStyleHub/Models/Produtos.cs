using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace theStyleHub.Models;

public class Produtos
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Nome { get; set; } = "";

    [Required]
    [Column(TypeName = "varchar(500)")]
    public string Descricao { get; set; } = "";

    [Required]
    [Column(TypeName = "varchar(20)")]
    public string Categoria { get; set; } = "";

    [Required]
    [Column(TypeName = "varchar(10)")]
    public string Cor { get; set; } = "";

    [Required]
    [Column(TypeName = "varchar(20)")]
    public string Genero { get; set; } = "";

    [Required]
    [Column(TypeName = "float")]
    public float Valor { get; set; }

    [Column(TypeName = "float")]
    public float Promocao {  get; set; }

    public List<Avaliacoes> Avaliacoes { get; set; }
    public List<Imagens> Imagens { get; set; }
    public List<ItensCarrinho> ItensCarrinho { get; set; }
    public List<ItensWishlist> ItensWishlist { get; set; }

}
