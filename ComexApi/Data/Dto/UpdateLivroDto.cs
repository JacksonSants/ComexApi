using System.ComponentModel.DataAnnotations;

namespace ComexApi.Data.Dto;

public class UpdateLivroDto
{
    public string Titulo { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Autor { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Descricao { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    public string ISBN { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    DateTime DatePublicacao { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    public bool Emprestado { get; set; }
    public int? ClienteId { get; set; }
}
