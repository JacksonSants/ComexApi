using System.ComponentModel.DataAnnotations;

namespace ComexApi.Data.Dtos;

public class UpdateEnderecoDto
{
    [Required(ErrorMessage = "O Bairro é obrigatório")]
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    [Required(ErrorMessage = "O Cidade é obrigatório")]
    public string Complemento { get; set; }
    [Required(ErrorMessage = "O Estado é obrigatório")]
    public string Estado { get; set; }
    [Required(ErrorMessage = "O Rua é obrigatório")]
    public string Rua { get; set; }
    [Required(ErrorMessage = "O Numero é obrigatório")]
    public int Numero { get; set; }
}
