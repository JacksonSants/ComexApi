using System.ComponentModel.DataAnnotations;

namespace ComexApi.Models;

public class Cliente
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O Nome é obrigatório")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O CPF é obrigatório")]
    [MaxLength(11, ErrorMessage = "O CPF deve ter até 11 caracteres.")]
    public string CPF { get; set; }

    [Required(ErrorMessage = "O Email é obrigatório")]
    public string Email  { get; set; }
    [Required(ErrorMessage = "A Profissao é obrigatório")]
    public string Profissao { get; set; }
    [Required(ErrorMessage = "O Telefone é obrigatório")]
    public string Telefone { get; set; }

    public int EnderecoId { get; set; }
    public virtual Endereco Endereco { get; set; }
}
