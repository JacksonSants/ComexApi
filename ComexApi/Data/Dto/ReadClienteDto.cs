using ComexApi.Models;

namespace ComexApi.Data.Dto;

public class ReadClienteDto
{
    public string Nome { get; set; }
    public virtual ICollection<ReadLivroDto> Livros { get; set; }
}
