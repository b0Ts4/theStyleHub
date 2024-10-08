namespace theStyleHub.Models;

public class ProdutoDTO
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Categoria { get; set; }
    public string Cor { get; set; }
    public string Genero { get; set; }
    public float Valor { get; set; }
    public float Promocao { get; set; }
    public List<string> ImagensBase64 { get; set; }
}
