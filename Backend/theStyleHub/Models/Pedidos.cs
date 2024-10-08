using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace theStyleHub.Models;

public class Pedidos
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime Data {  get; set; }

    [Required]
    [StringLength(100)]
    public string Status { get; set; } = "";

    [Required]
    public int Clerk_user_id { get; set; }
    
    [Required]
    public int Valor { get; set; }

    [ForeignKey("Clerk_user_id")]
    public Usuarios Usuario { get; set; }
    
    public List<Produtos> Produtos { get; set; }

    public Pedidos()
    {
        Produtos = new List<Produtos>();
    }
}
