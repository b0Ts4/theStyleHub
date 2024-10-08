using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace theStyleHub.Models;

public class Avaliacoes
{
    [Key]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "varchar(300)")]
    public string Conteudo { get; set; } = "";

    [Column(TypeName = "int")]
    public float Nota { get; set; }

    
    [ForeignKey("Clerk_user_id")]
    public Usuarios Usuario { get; set; }
    public int Clerk_user_id { get; set; }


    [ForeignKey("Id_produto")]
    public Produtos Produto { get; set; }
    public int Id_produto { get; set; }

    
    public List<Imagens> Imagens { get; set; }

}
