using System.ComponentModel.DataAnnotations;

namespace ComexApi.Models;

public class Cliente
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "Campo Nome obrigatório")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Campo CPF obrigatório")]
    public string CPF { get; set; }
    public virtual ICollection<Livro> Livros { get; set; }

}
