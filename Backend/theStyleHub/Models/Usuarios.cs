using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace theStyleHub.Models;

public class Usuarios
{
    [Key]
    public int Clerk_id { get; set; }

    [Column(TypeName = "varchar(11)")]
    public string CPF {  get; set; }

    [Required]
    [Column(TypeName = "varchar(100)")]
    public string Nome { get; set; } = "";

    [Column(TypeName = "varchar(300)")]
    public string Endereco { get; set; } = "";

    [Column(TypeName = "varchar(300)")]
    public string Hash_senha { get; set; } = "";


    public List<Produtos> Carrinho { get; set; } = new List<Produtos>();
    public List<Produtos> Wishlist { get; set; } = new List<Produtos>();
    public List<Avaliacoes> Avaliacoes { get; set; } = new List<Avaliacoes>();
    public List<Pedidos> Pedidos { get; set; } = new List<Pedidos>();


}
