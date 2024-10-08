using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace theStyleHub.Models;

public class Imagens
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(300)")]
    public string Caminho { get; set; } = "";

    [Required]
    [Column(TypeName = "varchar(10)")]
    public string TipoImagem { get; set; } = "";

    [ForeignKey("Id_produto")]
    public Produtos Produto { get; set; }
    public int? Id_produto { get; set; }

    [ForeignKey("Id_avaliacao")]
    public Avaliacoes avaliacoes { get; set; }
    public int? Id_avaliacao { get; set; }
}
