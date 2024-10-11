using System.ComponentModel.DataAnnotations;

namespace Estoque.Data.Dto;

public class CreateProdutoDto
{
    [Required(ErrorMessage = "Nome obrigatório")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Quantidade obrigatório")]
    public string Quantidade { get; set; }

    [Required(ErrorMessage = "Preçc obrigatório")]
    public float Preco { get; set; }
}
