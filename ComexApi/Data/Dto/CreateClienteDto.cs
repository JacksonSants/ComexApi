using ComexApi.Models;

namespace ComexApi.Data.Dto;

public class CreateClienteDto
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public virtual ICollection<Livro> Livros { get; set; }
}
