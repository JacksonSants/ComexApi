using System.ComponentModel.DataAnnotations;

namespace ComexApi.Models;

public class Categoria
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O Nome da categoria é obrigatório.")]
    public string Nome { get; set; }
    public virtual ICollection<Produto> Produtos { get; set; }
}
