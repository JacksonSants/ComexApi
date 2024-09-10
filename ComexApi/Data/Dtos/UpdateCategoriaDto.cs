using System.ComponentModel.DataAnnotations;

namespace ComexApi.Data.Dtos;

public class UpdateCategoriaDto
{
    [Required(ErrorMessage = "O Nome da categoria é obrigatório.")]
    public string Nome { get; set; }
}
