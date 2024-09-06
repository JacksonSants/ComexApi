using System.ComponentModel.DataAnnotations;

namespace ComexApi.Data.Dtos;

public class CreateProdutoDto
{
    [Required(ErrorMessage = "O Nome do produto é obrigatório.")]
    [StringLength(100, ErrorMessage = "O Nome do produto deve ter até 100 caracteres.")]
    public string Nome { get; set; }

    [StringLength(500, ErrorMessage = "A descrição do produto deve ter até 500 caracteres.")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "O PrecoUnitario é obrigatório.")]
    public double PrecoUnitario { get; set; }

    [Required(ErrorMessage = "A Quantidade é obrigatória.")]
    public int Quantidade { get; set; }
}
